using MyUnicam.Model;
using MyUnicam.Risorse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnicam.ViewModel
{    
    public class CarrieraStudenteVM
    {
        public string Titolo { get; private set; }

        private readonly ClientESSE3 _repo;
        private string retrieve = null;
        private string param = null;

        public CarrieraStudenteVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("CarrieraStudente", Dizionario.Culture);

            _repo = new ClientESSE3();

            //lettura corsi per anno accademico
            retrieve = "GET_CARRIERA";

            string aa = "" + DateTime.Now.Year + "";
            string data = "" + DateTime.Now + "";
            string dettagglio = "Sintetico";
            string codicefiscale = "CRRLSS93H29D542E";

            param = "AnnoAccademico=" + aa + ";DataScadenza= " + data + ";LivelloDettaglio="+ dettagglio+";CodiceFiscale="+codicefiscale+"";

            //LeggoDatiCarriera(retrieve, param);

        }

        private async void LeggoDatiCarriera(string retrieve, string param)
        {
            var xml = await _repo.RetrieveXml(retrieve, param);

        }
        
    }
}
