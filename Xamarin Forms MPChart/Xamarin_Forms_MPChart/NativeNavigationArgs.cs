using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Xamarin_Forms_MPChart
{
    public class NativeNavigationArgs
    {
        public Page GraphPage { get; private set; }
        public Double[] arrayValues { get; private set; }

        public NativeNavigationArgs(Page page, Double[] arrValues)
        {
            GraphPage = page;
            arrayValues = arrValues;
        }
    }
}
