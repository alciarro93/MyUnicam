using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyUnicam.Messaggi;
using MyUnicam.Model;
using MyUnicam.Pagine;
using System.Xml.Serialization;
using System.IO;
using MyUnicam.Risorse;

namespace MyUnicam.ViewModel
{
    public class OffertaFormativaVM : INotifyPropertyChanged 

    {
        public PaginaM[] TipiCorsi { get; private set; }

        public string Titolo { get; private set; }

        #region TIPO CORSO SELEZIONATO
        public PaginaM _paginaSelezionata;
        public PaginaM PaginaSelezionata
        {
            get
            {
                return _paginaSelezionata;
            }
            set
            {
                _paginaSelezionata = value;
                if (_paginaSelezionata != null)
                {
                    MyUnicam.App.Codice = _paginaSelezionata.GetCodice();
                    MessagingCenter.Send<PaginaSelezionata>(new PaginaSelezionata(_paginaSelezionata.TipoPagina),"");                  
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PaginaSelezionata"));
                }
                _paginaSelezionata = null;
            }
        }
        #endregion

        public OffertaFormativaVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("OffertaFormativa", Dizionario.Culture);

            TipiCorsi = new PaginaM[]
           {
                new PaginaM(typeof(Pagine.CorsiLaurea),"'L1','L2'"),
                new PaginaM(typeof(Pagine.CorsiLaurea),"'LS','LM'"),
                new PaginaM(typeof(Pagine.CorsiLaurea),"'LC5','LC6','LM6','LM5'"),
                new PaginaM(typeof(Pagine.CorsiLaurea),"'M1'"),
                new PaginaM(typeof(Pagine.CorsiLaurea),"'M2'"),
                new PaginaM(typeof(Pagine.CorsiLaurea),"'SP2','SP3','S4','SP5','SP6','S1','SHSP','CSS'"),
                new PaginaM(typeof(Pagine.CorsiLaurea),"'D1','D2'"),
                new PaginaM(typeof(Pagine.CorsiLaurea),"'TFA'"),
           };  
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
