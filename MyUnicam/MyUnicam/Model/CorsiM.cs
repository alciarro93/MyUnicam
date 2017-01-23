using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyUnicam.Model
{
    [XmlRoot("WS")]
    public class CorsiM
    {
        [XmlArray("DataSet")]
        [XmlArrayItem("Row")]
        public Corso[] Corso { get; set; }   
    }

    public class Corso
    {
        [XmlElement("fac_id")]
        public int IdFacCorso { get; set; }

        [XmlElement("p06_cds_des")]
        public string NomeCorso { get; set; }

        [XmlElement("p06_cds_cod")]
        public string CodiceCorso { get; set; }

        [XmlElement("p06_cdsord_valore_min")]
        public int Cfu { get; set; }

        [XmlElement("durata_anni")]
        public int DurataAnni { get; set; }

        [XmlElement("tipi_corso_tipo_corso_des")]
        public string TipoCorso { get; set; }

        [XmlElement("cds_id")]
        public string IdCds { get; set; }
        
    }  
}
