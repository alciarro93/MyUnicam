using MyUnicam.Messaggi;
using MyUnicam.Model;
using MyUnicam.Risorse;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MyUnicam
{
    public class App : Application
    {
        public static string Codice = null;
        public static string SecondoCodice = null;
        public static Object OggettoPassaggio = null;
        public App()
        {
            #region LINGUA DA SISTEMA
           
            string LinguaOS = CultureInfo.CurrentCulture.Name.ToString();

            if (LinguaOS.StartsWith("en"))
            {              
                Dizionario.Culture = new CultureInfo("en-GB");
            }
            else if (LinguaOS.StartsWith("it"))
            {
                Dizionario.Culture = new CultureInfo("it");
            }
            else if (LinguaOS.StartsWith("ar"))
            {
                Dizionario.Culture = new CultureInfo("ar-KW");
            }
            else if (LinguaOS.StartsWith("zh"))
            {
                Dizionario.Culture = new CultureInfo("zh");
            }
            else
            {
                Dizionario.Culture = new CultureInfo("en-GB");
            }
            #endregion

            // The root page of your application
            MainPage = new MyUnicam.Pagine.App();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
