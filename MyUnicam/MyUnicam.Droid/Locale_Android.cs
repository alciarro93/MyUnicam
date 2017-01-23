using System;
using Xamarin.Forms;
using System.Threading;

[assembly: Dependency(typeof(MyUnicam.Droid.Locale_Android))]

namespace MyUnicam.Droid
{
    public class Locale_Android : MyUnicam.Model.ILocale
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            //var androidLocale = Java.Util.Locale.Default;

            //var netLanguage = androidLocale.ToString().Replace("_", "-");

            //Console.WriteLine("android:" + androidLocale.ToString());
            //Console.WriteLine("net:" + netLanguage);

            //Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            //Console.WriteLine(Thread.CurrentThread.CurrentUICulture);

            return Thread.CurrentThread.CurrentUICulture;
        }

        public void SetLocale(string value)
        {
            var androidLocale = Java.Util.Locale.Default; // user's preferred locale
            var netLocale = androidLocale.ToString().Replace("_", "-");
            var ci = new System.Globalization.CultureInfo(value);

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}

