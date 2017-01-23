using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyUnicam.Model
{
    [XmlRoot("WS")]
    public class FacoltaM
    {
        [XmlArray("DataSet")]
        [XmlArrayItem("Row")]
        public Facolta[] Facolta { get; set; }
    }

    public class Facolta
    {
        [XmlElement("fac_id")]
        public int IdFac { get; set; }

        [XmlElement("des")]
        public String NomeFac {get; set;}
    }
}
