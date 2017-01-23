using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.Net;

namespace MyUnicam.Model
{
    public class ClientESSE3
    {

        private string sessionID = null;
        private const string guestUsername = "guest";
        private const string guestSessionID = "SESSIONIDGUEST";
        private const string urlServizio = "https://didattica.unicam.it/services/ESSE3WS";

        private const string richiestaLogin = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"https://didattica.unicam.it/services/ESSE3WS\" xmlns:types=\"https://didattica.unicam.it/services/ESSE3WS/encodedTypes\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><q1:fn_dologin xmlns:q1=\"http://ws.esse3.frk.kion.it\"><username xsi:type=\"xsd:string\">{0}</username><password xsi:type=\"xsd:string\">{1}</password><sid xsi:type=\"xsd:string\" /></q1:fn_dologin></soap:Body></soap:Envelope>";
        private const string richiestaLogout = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"https://didattica.unicam.it/services/ESSE3WS\" xmlns:types=\"https://didattica.unicam.it/services/ESSE3WS/encodedTypes\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><q1:fn_dologout xmlns:q1=\"http://ws.esse3.frk.kion.it\"><sid xsi:type=\"xsd:string\">{0}</sid></q1:fn_dologout></soap:Body></soap:Envelope>";
        private const string richiestaRetrieve = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"https://didattica.unicam.it/services/ESSE3WS\" xmlns:types=\"https://didattica.unicam.it/services/ESSE3WS/encodedTypes\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><q1:fn_retrieve_xml xmlns:q1=\"http://ws.esse3.frk.kion.it\"><sid xsi:type=\"xsd:string\">{0}</sid><retrieve xsi:type=\"xsd:string\">{1}</retrieve><params xsi:type=\"xsd:string\">{2}</params><xml xsi:type=\"xsd:string\" /></q1:fn_retrieve_xml></soap:Body></soap:Envelope>";


        private readonly Regex regexSidLogin;
        private readonly Regex regexXmlRetrieve;
        private readonly Regex regexEsito;


        public ClientESSE3()
        {
            regexSidLogin = new Regex("<sid.*?>(.*?)</sid>");
            regexXmlRetrieve = new Regex("<xml.*?>(.*?)</xml>", RegexOptions.Singleline);
            regexEsito = new Regex("<multiRef.*?>(.*?)</multiRef>");
        }

        public async Task<CodiciESSE3> Login(string username, string password)
        {

            if (username == guestUsername)
            {
                sessionID = guestSessionID;
                return CodiciESSE3.Ok;
            }

            using (var client = new HttpClient())
            {
                var contenutoRichiesta = new StringContent(string.Format(richiestaLogin, username, password), Encoding.UTF8, "text/xml");
                contenutoRichiesta.Headers.Add("SOAPAction", "\"\"");
                var risposta = await client.PostAsync(urlServizio, contenutoRichiesta);
                var contenutoRisposta = await risposta.Content.ReadAsStringAsync();
                sessionID = regexSidLogin.Match(contenutoRisposta).Groups[1].Captures[0].Value;
                var esitoLogin = (CodiciESSE3)int.Parse(regexEsito.Match(contenutoRisposta).Groups[1].Captures[0].Value);
                return esitoLogin;
            }
        }

        public async Task<CodiciESSE3> Logout()
        {
            if (string.IsNullOrEmpty(sessionID) || sessionID == guestSessionID)
            {
                sessionID = null;
                return CodiciESSE3.Ok;
            }

            using (var client = new HttpClient())
            {
                var contenutoRichiesta = new StringContent(string.Format(richiestaLogout, sessionID), Encoding.UTF8, "text/xml");
                contenutoRichiesta.Headers.Add("SOAPAction", "\"\"");
                var risposta = await client.PostAsync(urlServizio, contenutoRichiesta);
                var contenutoRisposta = await risposta.Content.ReadAsStringAsync();
                return (CodiciESSE3)int.Parse(regexEsito.Match(contenutoRisposta).Groups[1].Captures[0].Value);
            }
        }


        public async Task<string> RetrieveXml(string retrieve, string parameters)
        {

            using (var client = new HttpClient())
            {
                var contenutoRichiesta = new StringContent(string.Format(richiestaRetrieve, string.IsNullOrEmpty(sessionID) ? guestSessionID : sessionID, retrieve, parameters), Encoding.UTF8, "text/xml");
                contenutoRichiesta.Headers.Add("SOAPAction", "\"\"");
                var risposta = await client.PostAsync(urlServizio, contenutoRichiesta);
                var contenutoRisposta = await risposta.Content.ReadAsStringAsync();
                var xml = regexXmlRetrieve.Match(contenutoRisposta).Groups[1].Captures[0].Value;
                xml = WebUtility.HtmlDecode(xml);
                var esito = (CodiciESSE3)int.Parse(regexEsito.Match(contenutoRisposta).Groups[1].Captures[0].Value);
                return esito == CodiciESSE3.Ok ? xml : null;
                //return xml;
            }
        }

    }
}
