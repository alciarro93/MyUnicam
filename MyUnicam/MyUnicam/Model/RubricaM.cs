using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnicam.Model
{
    public class RubricaM : IComparable<RubricaM>
    {
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }

        public string InizialeCognome
        {
            get
            {
                return Cognome[0].ToString();
            }
        }

        int IComparable<RubricaM>.CompareTo(RubricaM value)
        {
            return Cognome.CompareTo(value.Cognome);
        }
    }
}
