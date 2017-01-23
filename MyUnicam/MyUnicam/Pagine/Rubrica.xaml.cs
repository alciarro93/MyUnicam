using MyUnicam.Model;
using MyUnicam.Risorse;
using MyUnicam.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyUnicam.Pagine
{
    public partial class Rubrica : ContentPage
    {
        public Rubrica()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.RubricaVM();
            if (Device.OS == TargetPlatform.Android)
            {
                this.ElencoRubrica.HasUnevenRows = true;
            }
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs ea)
        {
            var listItem = (RubricaM)ea.Item;
            var action= await DisplayActionSheet(Dizionario.RubricaTitoloPopUp,Dizionario.RubricaCancel,null,Dizionario.RubricaTelefono,Dizionario.RubricaEmail);
            if (action == Dizionario.RubricaEmail)
            {
                Device.OpenUri(new Uri("mailto:"+listItem.Email));
            }
            else if (action == Dizionario.RubricaTelefono)
            {
                Device.OpenUri(new Uri("tel:" + listItem.Tel));
            }
        }
    }
}
