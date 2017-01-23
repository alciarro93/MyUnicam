using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyUnicam.Model;
using MyUnicam.Messaggi;
using MyUnicam.Pagine;
using System.Globalization;
using MyUnicam.Risorse;


namespace MyUnicam.ViewModel
{
    public class HomeVM : INotifyPropertyChanged
    {
        private IRepositoryVisite _repo;
        public string Titolo { get; private set; }
        public PaginaM[] PagineQuick { get; private set; }

        #region LINK RAPIDO SELEZIONATO
        private PaginaM _paginaSelezionata;
        public PaginaM PaginaSelezionata
        {
            get
            {
                return _paginaSelezionata;
            }
            set
            {
                _paginaSelezionata = value;
                if (_paginaSelezionata != null)
                {
                    //controllo per evitare che la Home viene sempre aggiunta al database
                    if (_paginaSelezionata.TipoPagina != typeof(Pagine.Home))
                    {
                        var visita = new VisitaM { Pagina = _paginaSelezionata.TipoPagina.Name };
                        _repo.Aggiungi(visita);
                    }
                    //invia la pagina selezionata
                    MessagingCenter.Send<PaginaSelezionata>(new PaginaSelezionata(_paginaSelezionata.TipoPagina), "");
                    //notifica che è cambiata la pagina selezionata
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PaginaSelezionata"));
                }
                _paginaSelezionata = null;
            }
        }
        #endregion

        private IEnumerable<VisitaM> _visite;
        public IEnumerable<VisitaM> Visite
        {
            get
            {
                _visite = _repo.Elenca();  //prende le pagine più visualizzate
                foreach (VisitaM valore in _visite)
                {
                    //setta il nome della pagina in base alla lingua corrente
                    valore.NomePagina = Dizionario.ResourceManager.GetString(valore.Pagina, Dizionario.Culture);  
                    //notifica che è cambiato il NomePagina
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("NomePagina"));
                }
                return _visite;
            }
            set
            {
                _visite = value;
            }
        }

        public HomeVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("Home", Dizionario.Culture);
            _repo = DependencyService.Get<IRepositoryVisite>();

            /*Popola PagineQuick in base a quanti link rapidi sono registrati e aggiorna il NomePagina*/
            #region PAGINEQUICK
            if (Visite.Count<VisitaM>() == 0)
            {
                PagineQuick = new PaginaM[] { };
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PagineQuick"));
            }
            else if (Visite.Count<VisitaM>() == 1)
            {
                PagineQuick = new PaginaM[] {
                    new PaginaM(Type.GetType("MyUnicam.Pagine." + Visite.ElementAt<VisitaM>(0).Pagina))
                };
                AggiornaNomePagina(1);
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PagineQuick"));
            }
            else if (Visite.Count<VisitaM>() == 2)
            {
                PagineQuick = new PaginaM[] {
                    new PaginaM(Type.GetType("MyUnicam.Pagine." + Visite.ElementAt<VisitaM>(0).Pagina)),
                    new PaginaM(Type.GetType("MyUnicam.Pagine." + Visite.ElementAt<VisitaM>(1).Pagina))
                };
                AggiornaNomePagina(2);
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PagineQuick"));
            }
            else if (Visite.Count<VisitaM>() == 3)
            {
                PagineQuick = new PaginaM[] {
                    new PaginaM(Type.GetType("MyUnicam.Pagine." + Visite.ElementAt<VisitaM>(0).Pagina)),
                    new PaginaM(Type.GetType("MyUnicam.Pagine." + Visite.ElementAt<VisitaM>(1).Pagina)),
                    new PaginaM(Type.GetType("MyUnicam.Pagine." + Visite.ElementAt<VisitaM>(2).Pagina))
                };
                AggiornaNomePagina(3);
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PagineQuick"));
            }
            #endregion
        }

        //aggiorna NomePagina (attributo di PaginaM) per una corretta visualizzazione
        public void AggiornaNomePagina(int k)
        {
            for(int i=0; i<k; i++)
            {
                PagineQuick.ElementAt<PaginaM>(i).NomePagina = Visite.ElementAt<VisitaM>(i).NomePagina;
            }         
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
