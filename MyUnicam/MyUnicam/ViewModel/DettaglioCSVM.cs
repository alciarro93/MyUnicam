using MyUnicam.Risorse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnicam.ViewModel
{
    public class DettaglioCSVM
    {
        public string Titolo { get; private set; }
        public string TitoloCS { get; private set; }
        public string TestoCS { get; private set; }
        public DettaglioCSVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("ComunicatiStampa", Dizionario.Culture);
            TitoloCS = MyUnicam.App.Codice;
            TestoCS = MyUnicam.App.SecondoCodice;
            MyUnicam.App.Codice = null;
            MyUnicam.App.SecondoCodice = null;
        }
    }
}
