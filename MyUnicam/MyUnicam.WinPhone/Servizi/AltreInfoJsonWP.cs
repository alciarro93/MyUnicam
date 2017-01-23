using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUnicam.Model;
//using Newtonsoft.Json;
//using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(MyUnicam.WinPhone.Servizi.AltreInfoJsonWP))]
namespace MyUnicam.WinPhone.Servizi
{
    public class AltreInfoJsonWP : IRepositoryInformazioni
    {
        private RestSharp.RestClient client = null;
        private RestSharp.RestRequest request = null;
        public AltreInfoJsonWP()
        {
            client = new RestSharp.RestClient("http://156.54.99.64");
            client.AddHandler("text/html", new RestSharp.Deserializers.JsonDeserializer());
            request = new RestSharp.RestRequest("ws-app-unicam/index.php", RestSharp.Method.POST);
        }

        public async Task<List<CSM>> ElencaCS()
        {
            request.AddParameter("req", "1");
            var response = await client.ExecutePostTaskAsync<List<RisultatiCS>>(request);
            return response.Data.Select(i => new CSM
            {
                Titolo = i.titolo,
                Testo  = i.testo,
                Data   = i.data
            }).ToList();
        }

        public async Task<List<EventiM>> ElencaEventi()
        {
            request.AddParameter("req", "2");
            var response = await client.ExecutePostTaskAsync<List<RisultatiEventi>>(request);

            return response.Data.Select(i => new EventiM
            {
                Oggetto = i.oggetto,
                Luogo = i.luogo,
                Locandina = i.locandina,
                Programma = i.programma,
                DataInizio = i.data_inizio,
                DataFine = i.data_fine
            }).ToList();
        }

        public async Task<List<RubricaM>> ElencaRubrica()
        {
            request.AddParameter("req", "3");
            var response = await client.ExecutePostTaskAsync<List<RisultatiRubrica>>(request);
            return response.Data.Select(i => new RubricaM
            {
                Cognome = i.cognome,
                Nome    = i.nome,
                Email   = i.email,
                Tel     = i.tel,
                Fax     = i.fax
            }).ToList();
        }


    }
}
