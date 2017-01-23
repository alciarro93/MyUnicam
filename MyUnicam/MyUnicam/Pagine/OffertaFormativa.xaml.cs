using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyUnicam.Pagine
{
    public partial class OffertaFormativa : ContentPage
    {
        public OffertaFormativa()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.OffertaFormativaVM();
            if (Device.OS == TargetPlatform.Android)
            {
                this.ElencoTipiCorsi.HeightRequest = 440;
                this.ElencoTipiCorsi.RowHeight = 50;
            }
        }
    }
}
