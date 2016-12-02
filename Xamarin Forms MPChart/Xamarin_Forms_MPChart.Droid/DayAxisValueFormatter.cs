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

using MikePhil.Charting.Charts;
using MikePhil.Charting.Components;
using MikePhil.Charting.Formatter;

/*import com.github.mikephil.charting.charts.BarLineChartBase;
import com.github.mikephil.charting.components.AxisBase;
import com.github.mikephil.charting.formatter.IAxisValueFormatter;*/

namespace Xamarin_Forms_MPChart.Droid
{
    public class DayAxisValueFormatter
    {
        protected String[] mMonths = new String[]
        {
            "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dec"
        };

        private BarLineChartBase chart;

        public DayAxisValueFormatter(BarLineChartBase chart)
        {
            this.chart = chart;
        }

        private int determineYear(int days)
        {

            if (days <= 366)
                return 2016;
            else if (days <= 730)
                return 2017;
            else if (days <= 1094)
                return 2018;
            else if (days <= 1458)
                return 2019;
            else
                return 2020;

        }

        private int determineDayOfMonth(int days, int month)
        {

            int count = 0;
            int daysForMonths = 0;

            while (count < month)
            {

                int year = determineYear(daysForMonths);
                daysForMonths += DateTime.DaysInMonth(year, count % 12);
                count++;
            }

            return days - daysForMonths;
        }

        private int determineMonth(int dayOfYear)
        {

            int month = -1;
            int days = 0;

            while (days < dayOfYear)
            {
                month = month + 1;

                if (month >= 12)
                    month = 0;

                int year = determineYear(days);
                days += DateTime.DaysInMonth(year, month);
            }

            return Math.Max(month, 0);
        }

        public String getFormattedValue(float value, AxisBase axis)
        {

            int days = (int)value;

            int year = determineYear(days);

            int month = determineMonth(days);
            String monthName = mMonths[month % mMonths.Length];
            String yearName = year.ToString();

            if (chart.VisibleXRange > 30 * 6)
            {

                return monthName + " " + yearName;
            }
            else
            {

                int dayOfMonth = determineDayOfMonth(days, month + 12 * (year - 2016));

                String appendix = "th";

                switch (dayOfMonth)
                {
                    case 1:
                        appendix = "st";
                        break;
                    case 2:
                        appendix = "nd";
                        break;
                    case 3:
                        appendix = "rd";
                        break;
                    case 21:
                        appendix = "st";
                        break;
                    case 22:
                        appendix = "nd";
                        break;
                    case 23:
                        appendix = "rd";
                        break;
                    case 31:
                        appendix = "st";
                        break;
                }

                return dayOfMonth == 0 ? "" : dayOfMonth + appendix + " " + monthName;
            }
        }

    }
}