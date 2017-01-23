using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyUnicam.Pagine
{
    public partial class DettaglioCS : ContentPage
    {
        public DettaglioCS()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.DettaglioCSVM();
        }
    }
}
