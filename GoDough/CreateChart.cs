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

using OxyPlot;
using OxyPlot.Series;

namespace GoDough
{
    public class CreateChart
    {
        DatabaseDataHandler dataHandler = DatabaseDataHandler.Instance;
        private PlotModel modelP1;
        public CreateChart()
        {
            var chartSlices = new SortedList<string, double>();
            chartSlices.Add("Food", 1);
            chartSlices.Add("Clothing", 0);
            chartSlices.Add("Rent", 0);

            //var categories = dataHandler.Transactions.ToArray<>
            
            modelP1 = new PlotModel { Title = "Spending categories" };
            modelP1.Background = OxyColors.White;

            var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            /*
            seriesP1.Slices.Add(new PieSlice("Food", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP1.Slices.Add(new PieSlice("Clothing", 929) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Rent", 4157) { IsExploded = true });
            */

            for (int i = 0; i < chartSlices.Count; i++)
            {
                seriesP1.Slices.Add(new PieSlice(chartSlices.Keys[i], chartSlices.Values[i]) { IsExploded = true });
            }
                 
            modelP1.Series.Add(seriesP1);

        }

        public PlotModel Model1
        {
            get { return modelP1; }
            set { modelP1 = value; }
        }

    }
}