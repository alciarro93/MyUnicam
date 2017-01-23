using MyUnicam.Messaggi;
using MyUnicam.Model;
using MyUnicam.Risorse;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyUnicam.ViewModel
{
    public class RubricaVM : INotifyPropertyChanged
    {
        IRepositoryInformazioni _repo;
        public string Titolo { get; private set; }
        public ObservableCollection<RubricaMCollection> ListGroup { get; set; }

        private List<RubricaM> _rubrica;
        public List<RubricaM> Rubrica
        {
            get
            {
                return _rubrica;
            }
            set
            {
                _rubrica = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Rubrica"));
            }
        }

        public RubricaVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("Rubrica", Dizionario.Culture);

            _repo = DependencyService.Get<IRepositoryInformazioni>();
            LeggoRubrica();
        }

        private async void LeggoRubrica()
        {
            Rubrica = await _repo.ElencaRubrica();
            ListGroup = SetupList();
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ListGroup"));
        }


        private ObservableCollection<RubricaMCollection> SetupList()
        {
            var allListItemGroups = new ObservableCollection<RubricaMCollection>();
            foreach (var item in GetSortedData())
            {
                // Attempt to find any existing groups where theg group title matches the first char of our ListItem's name.
                var listItemGroup = allListItemGroups.FirstOrDefault(g => g.Iniziale == item.InizialeCognome);

                // If the list group does not exist, we create it.
                if (listItemGroup == null)
                {
                    listItemGroup = new RubricaMCollection(item.InizialeCognome);
                    listItemGroup.Add(item);
                    allListItemGroups.Add(listItemGroup);
                }
                else
                { // If the group does exist, we simply add the demo to the existing group.
                    listItemGroup.Add(item);
                }
            }
            return allListItemGroups;
        }


        public List<RubricaM> GetSortedData()
        {
            var items = Rubrica;
            items.Sort();
            return items;
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
