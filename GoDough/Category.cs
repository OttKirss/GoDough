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
using System.Collections;
using System.Collections.ObjectModel;

namespace GoDough
{
    [Activity(Label = "Category")]
    public class Category : Activity
    {
        Spinner categories;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Category);

            categories = FindViewById<Spinner>(Resource.Id.spinner1);
            var delete = FindViewById<Button>(Resource.Id.Delete);
            var add = FindViewById<Button>(Resource.Id.Add);
            var newCategory = FindViewById<EditText>(Resource.Id.edittext);

            //lisada categooria itemid 
            categories.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(categories_ItemSelected);

            ObservableCollection<string> items = new ObservableCollection<string>() { "one", "two", "three" };
            var adapter = new CategoriesAdapter(this, items);
            categories.Adapter = adapter;



            delete.Click += delegate
            {
                string myData = categories.SelectedItem.ToString();
                
                if (categories.SelectedItemId >= 0)
                {
                    items.Remove(myData);
                    adapter.NotifyDataSetChanged();
                }
                else
                {
                    //nothing in  spinner
                }
            };
            add.Click += delegate
            {
                string myData = newCategory.Text;


                    items.Add(newCategory.Text);
                    adapter.NotifyDataSetChanged();
                    //categories.SetSelection(adapter.GetPosition(myData));
         
            };
        }
        private void categories_ItemSelected(object sender, EventArgs e)
        {
            Spinner spinner = (Spinner)sender;
        }
    }
}
