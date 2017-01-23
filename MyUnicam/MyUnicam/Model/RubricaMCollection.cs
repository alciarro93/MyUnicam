using MyUnicam.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnicam.Model
{
    public class RubricaMCollection : ObservableCollection<RubricaM>
    {
        public string Iniziale { get; set; }

		public RubricaMCollection(string iniziale)
        {
            Iniziale = iniziale;
        }

    }
}
