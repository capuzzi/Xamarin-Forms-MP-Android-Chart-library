# Xamarin-Forms-MP-Android-Chart-library

A Xamarin.Forms binding for MPAndroidChart by Philipp Jahoda

For more information go to https://github.com/PhilJay/MPAndroidChart

This is a very simple project which shows how to use the MP Android Chart library in a Xamarin Forms project.

Use PM console to install library: https://www.nuget.org/packages/MPAndroidChart/3.0.1

The project has an XF homepage with a big button. By clicking the button open an Android Activity with a BarChart: the data is randomly generated.

An example of native project is: https://github.com/Flash3001/MPAndroidChart.Xamarin

A screenshot of the native android activity showing the BarChart:



![screenshot_2016-12-02-16-32-57](https://cloud.githubusercontent.com/assets/13660674/20839694/dba7a592-b8ad-11e6-92eb-b466f2a82a95.png)

This example shows how to open an Android Activity from a Xamarin Forms Page. When the button is clicked, it send a message to the MessagingCenter (Xamarin Forms HomePage.cs). In Xamarin.Android project, there is a "subscription" of this "message". When the message is pushed the subscriber (in Xamarin Android MainActivity.cs) handles the message opening a new activity containing the BarChart.

For more information see: https://developer.xamarin.com/guides/xamarin-forms/messaging-center/

