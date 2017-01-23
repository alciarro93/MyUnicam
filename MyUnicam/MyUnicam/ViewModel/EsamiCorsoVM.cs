using MyUnicam.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyUnicam.ViewModel
{
    public class EsamiCorsoVM : INotifyPropertyChanged
    {
        public string Titolo { get; private set; }
        public Corso OggettoRicevuto { get; set; }

        private readonly ClientESSE3 _repo ;
        private string retrieve = null;
        private string param = null;
        public string aa_id = "" + DateTime.Now.Year + "";

        public EsamiCorsoVM()
        {
            OggettoRicevuto=(Corso) MyUnicam.App.OggettoPassaggio;
            MyUnicam.App.OggettoPassaggio = null;
            this.Titolo = OggettoRicevuto.NomeCorso;

            _repo = new ClientESSE3();

            //lettura percorsi di studio
            retrieve = "LISTA_PDSORD";
            param = "aa_ord_id=" + aa_id + ";cds_id= " + OggettoRicevuto.IdCds + "";
            LeggiPercorso(retrieve, param);
            
        }


        private PercorsoStudioM _percorsoStudio;
        public PercorsoStudioM Percorso
        {
            get
            {
                return _percorsoStudio;
            }
            set
            {
                _percorsoStudio = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Percorso"));
            }
        }

        private async void LeggiPercorso(string retrieve, string param)
        {
            var xml = await _repo.RetrieveXml(retrieve, param);
            var serializer = new XmlSerializer(typeof(PercorsoStudioM));
            using (var reader = new StringReader(xml))
            {
                Percorso = serializer.Deserialize(reader) as PercorsoStudioM;
            }

            //lettura esami per un certo percorso di studio
            //retrieve = "LISTA_AD_PDSORD";
            //param = "aa_ord_id=" + aa_id + ";aa_off_id= " + aa_id + ";cds_id=" + OggettoRicevuto.NomeCorso + ";pds_id=" + Percorso.IdPds + "";
            //LeggiEsami(retrieve, param);
        }

        //private PercorsoStudioM _esamiCorso;
        //public PercorsoStudioM EsamiCorso
        //{
        //    get
        //    {
        //        return _esamiCorso;
        //    }
        //    set
        //    {
        //        _esamiCorso = value;
        //        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("EsamiCorso"));
        //    }
        //}

        //private async void LeggiEsami(string retrieve, string param)
        //{
        //    var xml = await _repo.RetrieveXml(retrieve, param);
        //    var serializer = new XmlSerializer(typeof(PercorsoStudioM));
        //    using (var reader = new StringReader(xml))
        //    {
        //        EsamiCorso = serializer.Deserialize(reader) as PercorsoStudioM;
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
