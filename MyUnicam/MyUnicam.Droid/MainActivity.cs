using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using System.Net;

namespace MyUnicam.Droid
{
    [Activity(Label = "MyUnicam", Icon = "@drawable/icon", Theme = "@style/StyleUnicam", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            // You may use ServicePointManager here
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            // Necessario per abilitare le Mappe
            Xamarin.FormsMaps.Init(this, bundle);
           
            // Accorgimenti di style per il material design
            if ((int)Android.OS.Build.VERSION.SdkInt >= 21) 
            {
                // Flag necessario per la colorazione della status bar
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                // Icona trasparente
                ActionBar.SetIcon ( 
                    new ColorDrawable (Resources.GetColor (Android.Resource.Color.Transparent)));
            }
            

            LoadApplication(new App());
        }
    }
}

