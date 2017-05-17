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
    public class Transaction
    {
        public int Money { get; set; }
        public string Category { get; set; }
        public Transaction(int money, string category)
        {
            Money = money;
            Category = category;
        }
        public Transaction()
        {
                
        }
    }
}