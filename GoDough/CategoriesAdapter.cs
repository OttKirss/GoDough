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
using System.Collections.ObjectModel;

namespace GoDough
{
    public class CategoriesAdapter : BaseAdapter<string>
    {
        ObservableCollection<string> items;
        Activity context;
        public CategoriesAdapter(Activity context, ObservableCollection<string> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.categoriesLayout, null);
            }


            view.FindViewById<TextView>(Resource.Id.textView1).Text = items[position];



            return view;
        }
    }
}
