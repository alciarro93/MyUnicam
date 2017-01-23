using MyUnicam.Messaggi;
using MyUnicam.Model;
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
    public class ComunicatiStampaVM : INotifyPropertyChanged
    {
        IRepositoryInformazioni _repo;
        public string Titolo { get; private set; }
        
        public ComunicatiStampaVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("ComunicatiStampa", Dizionario.Culture);

            _repo = DependencyService.Get<IRepositoryInformazioni>();
            LeggoCS();
        }

        private async void LeggoCS()
        {
            CS = await _repo.ElencaCS();
        }

        private List<CSM> _cs;
        public List<CSM> CS
        {
            get
            {
                return _cs;
            }
            set
            {
                _cs = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CS"));
            }
        }

        public CSM _csSelezionato;
        public CSM CSSelezionato
        {
            get
            {
                return _csSelezionato;
            }
            set
            {
                _csSelezionato = value;
                if (_csSelezionato != null)
                {
                    MyUnicam.App.Codice = _csSelezionato.Titolo;
                    MyUnicam.App.SecondoCodice= _csSelezionato.Testo;
                    MessagingCenter.Send<PaginaSelezionata>(new PaginaSelezionata(typeof(Pagine.DettaglioCS)), "");
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CSSelezionato"));
                }
                _csSelezionato = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
