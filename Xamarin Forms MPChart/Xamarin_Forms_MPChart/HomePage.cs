using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Xamarin_Forms_MPChart
{
    public class HomePage: ContentPage
    {
        public HomePage()
        {
            Button button = new Button();
            button.Text = "open graph page";
            Content = button;
            button.Clicked += Button_Clicked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Double[] arrValues = new Double[] {1,2};

            MessagingCenter.Send(this,"message",new NativeNavigationArgs(new PageToNativeBarChart(),arrValues));
        }
    }
}
