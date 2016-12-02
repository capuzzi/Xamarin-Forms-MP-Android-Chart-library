using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

using MikePhil.Charting.Charts;
using MikePhil.Charting.Components;
using MikePhil.Charting.Data;
using MikePhil.Charting.Formatter;
using MikePhil.Charting.Highlight;
using MikePhil.Charting.Interfaces;
using MikePhil.Charting.Listener;
using MikePhil.Charting.Util;
using MikePhil.Charting.Buffer;
using MikePhil.Charting.Animation;
using MikePhil.Charting.Exception;
using MikePhil.Charting.Jobs;

using Java.Lang;

using Xamarin.Forms;

namespace Xamarin_Forms_MPChart.Droid
{
    [Activity(Label = "BarChart")]
    public class BarChartActivity : Activity
    {
        protected BarChart mChart;
        private SeekBar mSeekBarX, mSeekBarY;
        private TextView tvX, tvY;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var relLayout = new Android.Widget.RelativeLayout(this);


            tvX = new TextView(this);
            tvY = new TextView(this);
            tvX.Text = "textview xx";
            tvY.Text = "textview yy";

            mChart = new BarChart(this);
            mChart.SetDrawBarShadow(false);
            mChart.SetDrawValueAboveBar(true);
            mChart.Description.Enabled = true;
            mChart.SetMaxVisibleValueCount(60);
            mChart.SetPinchZoom(true);
            mChart.SetBackgroundColor(Android.Graphics.Color.White);

            XAxis xaxis = new XAxis();
            DayAxisValueFormatter xAxisFormatter = new DayAxisValueFormatter(mChart);

            XAxis xAxis = mChart.XAxis;
            xaxis.SetDrawGridLines(false);
            xaxis.SetLabelCount(7, false);

            setData(12, 50);
   
            relLayout.AddView(mChart, 650, 1000);


            SetContentView(relLayout);
        }

        private void setData(int count, float range)
        {
            float start = 1f;
                        
            List <BarEntry> yVals1 = new List<BarEntry>();

            for (int i = (int)start; i < start + count + 1; i++)
            {
                float mult = (range + 1);
                //random data
                float val = (float)(Java.Lang.Math.Random() * mult);
                yVals1.Add(new BarEntry(i, val));
            }

            BarDataSet set1;

            if(mChart.Data != null && mChart.BarData.DataSetCount >0)
            {
                set1 = (BarDataSet) mChart.BarData.GetDataSetByIndex(0);
                set1.Values = yVals1;
                mChart.BarData.NotifyDataChanged();
                mChart.NotifyDataSetChanged();

                mChart.BarData.AddDataSet(set1);
            }
            else
            {
                set1 = new BarDataSet(yVals1, "2017");

                List<MikePhil.Charting.Interfaces.Datasets.IBarDataSet> dataSets = new List<MikePhil.Charting.Interfaces.Datasets.IBarDataSet>();

                dataSets.Add(set1);
                BarData data = new BarData(dataSets);

                dataSets.Add(set1);
                mChart.Data = data;
            }
        }
    }
}