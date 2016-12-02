using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

using Xamarin.Forms;

namespace Xamarin_Forms_MPChart.Droid
{
	[Activity (Label = "Xamarin_Forms_MPChart", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            //receive message and handle it
            MessagingCenter.Subscribe<HomePage, NativeNavigationArgs>(this,"message", HandleNativeNavigationArgs);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new Xamarin_Forms_MPChart.App ());
		}

        private void HandleNativeNavigationArgs(HomePage sender, NativeNavigationArgs args)
        {
            //when receive message open a new Activity using Android Intent
            Intent activity = new Intent(this, typeof(BarChartActivity));
            StartActivity(activity);
        }
	}
}

