using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUnicam.Messaggi;
using Xamarin.Forms;
using MyUnicam.Model;
using MyUnicam.Risorse;

namespace MyUnicam.Pagine
{
    public partial class App : MasterDetailPage
    {
        //IViewConArgs _arg;
        public App()
        {    
            InitializeComponent();           

            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
            {
                this.Master = new Menu();
            }
            else
            {
                this.Master = new Menu() { Icon = "MenuIcon.png" };
            }

            this.Detail = new NavigationPage(new Home());


            MessagingCenter.Subscribe<PaginaSelezionata>(this, "", (sender) =>
            {
                var tipoPagina = sender.TipoPagina;            
                var LastPage= this.Detail.Navigation.NavigationStack.Last<Page>();

                if (tipoPagina != LastPage.GetType() && tipoPagina!= typeof(OrarioLezioni))
                {
                    var pagina = (Page)Activator.CreateInstance(tipoPagina);
                    this.Detail.Navigation.PushAsync(pagina);
                    IsPresented = false;                  
                }
                if (tipoPagina == typeof(OrarioLezioni))
                {
                    IsPresented = true;
                    var uri = new Uri("http://www.unicam.it/studenti/OrariLezioni/");
                    Device.OpenUri(uri);
                }
            });           
        }
    }
}
