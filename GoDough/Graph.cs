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
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace GoDough
{
	[Activity(Label = "Graph")]
	public class Graph : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Graph);

            PlotView view = FindViewById<PlotView>(Resource.Id.plotView1);
            CreateChart pieChart = new CreateChart();
            view.Model = pieChart.Model1;

        }
    }
}