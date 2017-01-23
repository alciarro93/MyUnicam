using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyUnicam.Pagine
{
    public partial class Eventi : ContentPage
    {
        public Eventi()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.EventiVM();
            if (Device.OS == TargetPlatform.Android)
            {
                this.ElencoEventi.HasUnevenRows = true;
            }
        }
    }
}
