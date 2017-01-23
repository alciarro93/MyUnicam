using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyUnicam.Model
{
    public class VideoM
    {
        public string Nome { get; set; }
        public ImageSource Immagine { get; set; }
        public DateTime Data { get; set; }
        public string Link { get; set; }
    }
}
