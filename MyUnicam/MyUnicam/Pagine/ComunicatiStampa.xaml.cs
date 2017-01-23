using MyUnicam.Messaggi;
using MyUnicam.Model;
using MyUnicam.Risorse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyUnicam.Pagine
{
    public partial class ComunicatiStampa : ContentPage
    {
        public ComunicatiStampa()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.ComunicatiStampaVM();
            if (Device.OS == TargetPlatform.Android)
            {
                this.ElencoCS.HasUnevenRows = true;
            }
        }
    }
}
