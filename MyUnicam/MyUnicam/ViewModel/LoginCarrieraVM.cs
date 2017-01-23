using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyUnicam.Model;
using System.ComponentModel;
using MyUnicam.Messaggi;
using System.Windows.Input;
using MyUnicam.Risorse;

namespace MyUnicam.ViewModel
{
    class LoginCarrieraVM : INotifyPropertyChanged
    {
        public string Titolo { get; private set; }
        public VideoM[] DidatticaLink { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public LoginCarrieraVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("LoginCarriera", Dizionario.Culture);

            //link web didattica
            DidatticaLink = new VideoM[]
            { 
                new VideoM{
                    Immagine = "DidatticaLink.png",
                    Link = "https://didattica.unicam.it/esse3/Home.do",
                    Nome = Dizionario.DidatticaLink
                }
            };
            //login in app
            this.EffettuaLogin = new Command(Login);
            
        }

        //link alla didattica
        private VideoM _linkSelezionato;
        public VideoM LinkSelezionato
        {
            get
            {
                return _linkSelezionato;
            }
            set
            {
                _linkSelezionato = value;
                if (_linkSelezionato != null)
                    Device.OpenUri(new Uri(_linkSelezionato.Link));
                _linkSelezionato = null;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("LinkSelezionato"));
            }
        }



        public ICommand EffettuaLogin { get; set; }

        private void Login()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)){
                ErroreDiLogin = Dizionario.ResourceManager.GetString("ErroreDiLogin", Dizionario.Culture);
                return;
            }
            //var _repo = new Esse3Carriera.Esse3StudentWSClient();

            //_repo.loginCompleted += _repo_loginCompleted;

            //_repo.loginAsync(Username, Password);

        }

        //void _repo_loginCompleted(object sender, Esse3Carriera.loginCompletedEventArgs e)
        //{
        //    var x = e.Error;
        //    MessagingCenter.Send<PaginaSelezionata>(new PaginaSelezionata(typeof(Pagine.CarrieraStudente)), "");
        //    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PaginaSelezionata"));
        //}


        private string _erroreDiLogin;
        public string ErroreDiLogin
        {
            get
            {
                return _erroreDiLogin;
            }
            set
            {
                _erroreDiLogin = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ErroreDiLogin"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ErroreDiLoginVisibile"));
                }
                
            }
        }
        //rende visibile l'errore se presente, oppure lo lascia nascosto
        public bool ErroreDiLoginVisibile
        {
            get
            {
                return !string.IsNullOrEmpty(ErroreDiLogin);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
