using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyUnicam;


[assembly: Dependency(typeof(MyUnicam.WinPhone.Locale_WinPhone))]

namespace MyUnicam.WinPhone
{
    public class Locale_WinPhone : MyUnicam.Model.ILocale
    {
        public void SetLocale(string value)
        {
            System.Globalization.CultureInfo ci;
            try
            {
                ci = new System.Globalization.CultureInfo(value);

            }
            catch
            {
                ci = new System.Globalization.CultureInfo(GetCurrentCultureInfo().Name);
            }
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture;
        }
    }
}