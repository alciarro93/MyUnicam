using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyUnicam.Pagine
{
    public partial class EsamiCorso : ContentPage
    {
        public EsamiCorso()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.EsamiCorsoVM();
        }
    }
}
