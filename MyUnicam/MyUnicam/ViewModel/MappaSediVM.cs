using MyUnicam.Messaggi;
using MyUnicam.Risorse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyUnicam.ViewModel
{
    public class MappaSediVM
    {
        public string Titolo { get; private set; }

        public MappaSediVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("MappaSedi", Dizionario.Culture);
        }
    }
}
