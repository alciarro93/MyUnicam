using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyUnicam.Pagine
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            
            this.BindingContext= new ViewModel.MenuVM();

            if (Device.OS == TargetPlatform.Android) {
                this.StackMenu.HeightRequest = 550;
                this.PagineMenu.RowHeight = 50;
                this.StudentiMenu.RowHeight = 50;
                this.BannerStu.HeightRequest = 50;
                this.BannerUni.HeightRequest = 50;
            }           
        }
    }
}
