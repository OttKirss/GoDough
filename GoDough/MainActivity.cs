using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace GoDough
{
    [Activity(Label = "GoDough", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        DatabaseDataHandler dataHandler = DatabaseDataHandler.Instance;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            var balanceleft = FindViewById<TextView>(Resource.Id.BalLeft);
            var toCategory = FindViewById<Button>(Resource.Id.toGategory);
            var toGraph = FindViewById<Button>(Resource.Id.toGraph);
            var addBal = FindViewById<Button>(Resource.Id.button1);
            var balance = FindViewById<EditText>(Resource.Id.balNumber);
            var toTransactions = FindViewById<Button>(Resource.Id.toTransactions);

           
            balanceleft.Text = "Balance left this month: " + dataHandler.UserData.Balance.ToString();

            toCategory.Click += delegate 
            {
                StartActivity(typeof(Category));
            };
            toGraph.Click += delegate
            {
                StartActivity(typeof(Graph));
            };
            toTransactions.Click += delegate
            {
                StartActivity(typeof(Transactions));
            };
            addBal.Click += delegate
            {
                if (balance.Text != "")
                {
                    balanceleft.Text = balance.Text;
                    dataHandler.addBalanceToDatabase(Convert.ToInt32(balance.Text));
                    //lisada balance1 andmebaasi
                    //see on kuupalk mida kasutaja sisestab
                }
                else
                {
                    Toast.MakeText(this, "Amount of money is not inserted", ToastLength.Long).Show();
                }
            };

        }
    }
}

