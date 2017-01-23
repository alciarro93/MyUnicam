using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnicam.Messaggi
{
    public class PaginaSelezionata
    {
        public Type TipoPagina { get; private set; }

        public PaginaSelezionata(Type tipoPagina)
        {
            this.TipoPagina = tipoPagina;
        }

    }
}
