using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyUnicam.Pagine
{
    public partial class Video : ContentPage
    {
        public Video()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.VideoVM();
        }
    }
}
