using MyUnicam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyUnicam.Pagine
{
    public partial class LoginCarriera : ContentPage
    {
        public LoginCarriera()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.LoginCarrieraVM();
            if (Device.OS == TargetPlatform.WinPhone)
            {
                //this.UsernameEntry.BackgroundColor = Color.Blue;
                //this.PasswordEntry.BackgroundColor = Color.Blue;
                this.DoLogin.BorderColor = Color.FromHex("212F4A");
                this.DoLogin.TextColor = Color.FromHex("212F4A");
            }
            if (Device.OS == TargetPlatform.Android)
            {
                this.DoLogin.BackgroundColor = Color.FromHex("545D7F");
            }
        }
    }
}
