using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;
using System.Resources;

namespace MyUnicam.Model
{
    public class Localize
    {
        static readonly CultureInfo ci;

        static Localize()
        {
            ci = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
        }

        public static string GetString(string key, string comment)
        {
            ResourceManager temp = new ResourceManager("MyUnicam.Risorse", typeof(Localize).GetTypeInfo().Assembly);

            string result = temp.GetString(key, ci);

            return result;
        }
    }
}
