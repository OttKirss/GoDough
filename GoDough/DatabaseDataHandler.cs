using System;
using System.IO;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GoDough
{
    public sealed class DatabaseDataHandler
    {
        
        private static DatabaseDataHandler instance = null;
        private static readonly object padlock = new object();
        string dbPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Personal),
        "Ores.db3");


        public User UserData { get; set; }
        public ObservableCollection<Transaction> Transactions = new ObservableCollection<Transaction>();


        
        SqliteConnection connection;



        DatabaseDataHandler()
        {

            if (!File.Exists(dbPath))
            {
                // Need to create the database before seeding it with some data
                SqliteConnection.CreateFile(dbPath);

                var commands = new[] {
                "CREATE TABLE UserData (balance INTEGER, currency VARCHAR(1));",
                "INSERT INTO UserData (balance, currency) VALUES ('0','€')",
                "CREATE TABLE Transactions (money INTEGER, category VARCHAR(255));"
                };

                connection = new SqliteConnection("Data Source=" + dbPath);
                connection.Open();

                foreach (var command in commands)
                {
                    executeCommand(command);
                }
                connection.Close();

                initializeData();
            }
            else
            {

                // Open connection to existing database file
                connection = new SqliteConnection("Data Source=" + dbPath);
                initializeData();

            }
        }


        public static DatabaseDataHandler Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseDataHandler();
                    }
                    return instance;
                }
            }
        }



        /// <summary>
        /// Execute a sql command that isn't supposed to return anything, ex: UPDATE, INSERT, CREATE etc (no connection opening or closing)
        /// </summary>
        /// <param name="query">The sql Query to execute</param>
        private void executeCommand(string query)
        {
            using (var contents = connection.CreateCommand())
            {
                contents.CommandText = query;
                var r = contents.ExecuteNonQuery();
            }
        }

     
        /// <summary>
        /// Gets the stored data from the local database (prob vahetan nime ära millalgi xd)
        /// </summary>
        public void initializeData()
        {
            UserData = new User();
            //init some values 
            connection.Open();
            getUserData();
            getTransactions();
            connection.Close();
        }
        /// <summary>
        /// Gets the stored data from the local database (prob vahetan nime ära millalgi xd)
        /// </summary>
        private void getUserData()
        {
            using (var contents = connection.CreateCommand())
            {
                contents.CommandText = "SELECT * from UserData";
                var r = contents.ExecuteReader();

                UserData.Balance = Convert.ToInt32(r["balance"].ToString());

            }
        }
        private void getTransactions()
        {
            using (var contents = connection.CreateCommand())
            {
                contents.CommandText = "SELECT * from Transactions";
                var r = contents.ExecuteReader();
                while (r.Read())//multiple rows
                {
                    Transactions.Add(new Transaction(Convert.ToInt32(r["balance"].ToString()), r["category"].ToString()));
                }
            }
        }
        public void addTransactionToDatabase(Transaction transaction)
        {

            Transactions.Add(transaction);
            connection.Open();
            executeCommand("INSERT INTO Transactions (money,category) VALUES ("+transaction.Money+",'"+transaction.Category+"')");
            connection.Close();
        }
        public void addBalanceToDatabase(int balance)
        {

            UserData.Balance = balance;
            connection.Open();
            executeCommand("UPDATE UserData SET balance = " + balance);
            connection.Close();
        }



        /// <summary>
        /// Saves Data to database
        /// </summary>
        public void saveDataDatabase()
        {
            connection.Open();
            executeCommand("UPDATE userData SET balance ='" + UserData.Balance + "' ;");
            connection.Close();
        }

        
    }

}