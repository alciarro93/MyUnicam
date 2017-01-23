using MyUnicam.Messaggi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyUnicam.Model;
using MyUnicam.Risorse;

namespace MyUnicam.ViewModel
{
    public class EventiVM : INotifyPropertyChanged
    {
        IRepositoryInformazioni _repo;
        public string Titolo { get; private set; }

        private EventiM _eventoSelezionato;

        public EventiM EventoSelezionato
        {
            get
            {
                return _eventoSelezionato;
            }
            set
            {
                _eventoSelezionato = value;
                if (_eventoSelezionato != null)
                    Device.OpenUri(new Uri(_eventoSelezionato.Programma));
                _eventoSelezionato = null;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("EventoSelezionato"));
            }
        }

        public EventiVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("Eventi", Dizionario.Culture);

            _repo= DependencyService.Get<IRepositoryInformazioni>();
            LeggoEventi();            
        }

        private async void LeggoEventi()
        {
            Evento = await _repo.ElencaEventi();
        }



        private List<EventiM> _evento;
        public List<EventiM> Evento
        {
            get
            {
                return _evento;
            }
            set
            {
                _evento = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Evento"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
