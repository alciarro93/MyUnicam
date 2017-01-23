using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUnicam.Model;
using Xamarin.Forms;
using MyUnicam.Messaggi;


namespace MyUnicam.Pagine
{
    public partial class CorsiLaurea : ContentPage
    {
        public CorsiLaurea()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.CorsiLaureaVM();
            if (Device.OS == TargetPlatform.Android)
            {
                this.ElencoTipiCorsi.HeightRequest = 600;
                this.ElencoTipiCorsi.RowHeight = 50;
            }
        }
    }
}
