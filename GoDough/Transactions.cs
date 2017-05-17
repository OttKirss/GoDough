using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GoDough
{
    [Activity(Label = "Transactions")]
    public class Transactions : Activity
    {
        DatabaseDataHandler dataHandler = DatabaseDataHandler.Instance;
        ListView pastTransactions;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Transactions);

            var spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            var moneyAmount = FindViewById<EditText>(Resource.Id.editText1);
            pastTransactions = FindViewById<ListView>(Resource.Id.pastTrans);
            var button = FindViewById<Button>(Resource.Id.button1);

            var adapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.spending_categories, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            updateListView();

            button.Click += delegate
            {
                if (moneyAmount.Text != "")
                {
                    int money = Convert.ToInt32(moneyAmount.Text);
                    string category = spinner.SelectedItem.ToString();

                    dataHandler.addTransactionToDatabase(new Transaction(money,category));
                    updateListView();
                }
                else
                {
                    Toast.MakeText(this, "Amount of money is not inserted", ToastLength.Long).Show();
                }
            };
        }
        private void updateListView()
        {
            //updateda listview transactionitega
        }
    }
}