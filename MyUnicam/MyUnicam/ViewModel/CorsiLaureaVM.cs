using MyUnicam.Messaggi;
using MyUnicam.Model;
using MyUnicam.Risorse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace MyUnicam.ViewModel
{
    class CorsiLaureaVM : INotifyPropertyChanged
    {
        public string Titolo { get; private set; }

        private readonly ClientESSE3 _repo;
        private string retrieve = null;
        private string param = null;


        public CorsiLaureaVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("CorsiLaurea", Dizionario.Culture);
            _repo = new ClientESSE3();

            //codice per identificare quale offerta formativa è stata selezionata
            var codice = MyUnicam.App.Codice;
            App.Codice = null;

            string aa_id = "" + DateTime.Now.Year+"";

            //lettura corsi per anno accademico
            retrieve = "CDS_FACOLTA";
            param = "aa_id=" + aa_id + ";tipo_corso= " + codice + "";
            LeggiDatiCorso(retrieve, param);
            
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
                    MyUnicam.App.OggettoPassaggio = _corsoSelezionato;
                    MessagingCenter.Send<PaginaSelezionata>(new PaginaSelezionata(typeof(Pagine.DettaglioCorso)), "");
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PaginaSelezionata"));
                    _corsoSelezionato = null;
                }                
            }
        }


        /*chiama il metodo RetriveXml e deserializza l'xml così da estrarre dati opportuni*/

        private CorsiM _corsiLaurea;
        public CorsiM CorsiLaurea
        {
            get
            {
                return _corsiLaurea;
            }
            set
            {
                _corsiLaurea = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CorsiLaurea"));
            }
        }
               
        //corsi di laurea
        private async void LeggiDatiCorso(string retrieve, string param)
        {
            var xml = await _repo.RetrieveXml(retrieve, param);
            var serializer = new XmlSerializer(typeof(CorsiM));
            using (var reader = new StringReader(xml))
            {
                CorsiLaurea = serializer.Deserialize(reader) as CorsiM;
            }

            /*Chiamata per prelevare le facoltà*/
            //lettura facoltà
            //retrieve = "FACOLTA";
            //param = "";
            //LeggiDatiFac(retrieve, param);
        }

        #region FACOLTA'
        //private FacoltaM _facolta;
        //public FacoltaM Facolta
        //{
        //    get
        //    {
        //        return _facolta;
        //    }
        //    set
        //    {
        //        _facolta = value;
        //        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Facolta"));
        //    }
        //}

        ////facoltà
        //private async void LeggiDatiFac(string retrieve,string param)
        //{
        //    var xml = await _repo.RetrieveXml(retrieve, param);
        //    var serializer = new XmlSerializer(typeof(FacoltaM));
        //    using (var reader = new StringReader(xml))
        //    {
        //        Facolta = serializer.Deserialize(reader) as FacoltaM;
        //    }
        //}
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
