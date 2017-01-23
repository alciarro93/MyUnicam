using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnicam.Model
{
    public class RisultatiEventi
    {
        public int ID { get; set; }
        public string oggetto { get; set; }
        public string luogo { get; set; }
        public string locandina { get; set; }
        public string programma { get; set; }
        public string data_inizio { get; set; }
        public string data_fine { get; set; }
    }

}
