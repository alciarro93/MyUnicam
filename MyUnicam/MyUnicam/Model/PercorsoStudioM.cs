using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyUnicam.Model
{
    [XmlRoot("WS")]
    public class PercorsoStudioM
    {
        [XmlArray("DataSet")]
        [XmlArrayItem("Row")]
        public PercorsoStudio[] PercorsoStudio { get; set; } 
    }

    public class PercorsoStudio
    {
        [XmlElement("pds_id")]
        public string IdPds { get; set; }
    }
}
