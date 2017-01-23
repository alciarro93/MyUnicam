using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyUnicam.Pagine
{
    public partial class DettaglioCorso : ContentPage
    {
        public DettaglioCorso()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.DettaglioCorsoVM();
        }
    }
}
