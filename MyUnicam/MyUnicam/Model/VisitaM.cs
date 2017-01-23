using MyUnicam.Messaggi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyUnicam.Model
{
    public class VisitaM
    {
        public int Id { get; set; }
        public string Pagina { get; set; }   //attributo che determina il nome della pagina visitata 
        public string NomePagina{ get; set; }
    }
}
