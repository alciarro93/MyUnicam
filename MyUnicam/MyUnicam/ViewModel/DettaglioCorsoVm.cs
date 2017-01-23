using MyUnicam.Messaggi;
using MyUnicam.Model;
using MyUnicam.Risorse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyUnicam.ViewModel
{

    public class DettaglioCorsoVM : INotifyPropertyChanged
    {
        public string Titolo { get; private set; }
        public Corso OggettoRicevuto { get; set; }
        public Corso[] ListaEsamiCorso { get; set; } 

        public DettaglioCorsoVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("DettaglioCorso", Dizionario.Culture);
            OggettoRicevuto = (Corso)MyUnicam.App.OggettoPassaggio;
            MyUnicam.App.OggettoPassaggio = null;
            ListaEsamiCorso = new Corso[]
            { 
                new Corso{
                        IdFacCorso = OggettoRicevuto.IdFacCorso,
                        NomeCorso = OggettoRicevuto.NomeCorso,
                        CodiceCorso = OggettoRicevuto.CodiceCorso,
                        Cfu = OggettoRicevuto.Cfu,
                        DurataAnni = OggettoRicevuto.DurataAnni,
                        TipoCorso = OggettoRicevuto.TipoCorso,
                        IdCds=OggettoRicevuto.IdCds
                }
            };
        }

        public Corso _corsoSelezionato;
        public Corso CorsoSelezionato
        {
            get
            {
                return _corsoSelezionato;
            }
            set
            {
                _corsoSelezionato = value;
                if (_corsoSelezionato != null)
                {
                    //MyUnicam.App.Codice = _corsoSelezionato.CodiceCorso;
                    MyUnicam.App.OggettoPassaggio = _corsoSelezionato;
                    MessagingCenter.Send<PaginaSelezionata>(new PaginaSelezionata(typeof(Pagine.EsamiCorso)), "");
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PaginaSelezionata"));                   
                }
                _corsoSelezionato = null;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
