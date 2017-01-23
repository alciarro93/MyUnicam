using MyUnicam.Risorse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyUnicam.Pagine
{
    public partial class MappaSedi : TabbedPage
    {
        public MappaSedi()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.MappaSediVM();
            if (Device.OS == TargetPlatform.WinPhone)
            {
                this.BackgroundColor = Color.FromHex("212F4A");
            }
            this.Children.Add(new MyUnicam.Pagine.TabMappaSedi.Mappa() { Title = Dizionario.Mappa });
            this.Children.Add(new MyUnicam.Pagine.TabMappaSedi.Sedi() { Title = Dizionario.Sedi });
            
        }
    }
}
