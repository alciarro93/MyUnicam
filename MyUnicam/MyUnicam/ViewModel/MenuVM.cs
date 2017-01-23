using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyUnicam.Messaggi;
using MyUnicam.Model;
using MyUnicam.Pagine;
using Xamarin.Forms;

namespace MyUnicam.ViewModel
{
   public class MenuVM : INotifyPropertyChanged
   {

       private IRepositoryVisite _repo;

       // Parte inerente alle Pagine del Menu
       public PaginaM[] PagineMenu { get; private set; }
       // Parte inerente alla sezione Studenti
       public PaginaM[] Studenti { get; private set; }

       #region PAGINA DEL MENU SELEZIONATA
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
                       var visita = new VisitaM { Pagina = _paginaSelezionata.TipoPagina.Name};
                       _repo.Aggiungi(visita);
                   }             
                   //invia la pagina selezionata  
                   MessagingCenter.Send<PaginaSelezionata>(new PaginaSelezionata(_paginaSelezionata.TipoPagina), "");
                   _paginaSelezionata = null;
                   //notifica che è cambiata la pagina selezionata
                   if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PaginaSelezionata"));
               } 
               
           }
       }
       #endregion

       // Costruttore
       public MenuVM()
       {
           //repo prende le specifiche dell'interfaccia IRepositoryVisite
           _repo = DependencyService.Get<IRepositoryVisite>();  

           PagineMenu = new PaginaM[]
           {
                new PaginaM(typeof(Pagine.Home)),
                new PaginaM(typeof(Pagine.OffertaFormativa)),
                new PaginaM(typeof(Pagine.Eventi)),
                new PaginaM(typeof(Pagine.ComunicatiStampa)),
                new PaginaM(typeof(Pagine.Video)),
                new PaginaM(typeof(Pagine.Rubrica)),
                new PaginaM(typeof(Pagine.MappaSedi)),             
           };

           Studenti = new PaginaM[]
           {
               new PaginaM(typeof(Pagine.OrarioLezioni)),
               new PaginaM(typeof(Pagine.LoginCarriera))
           };

       }

       public event PropertyChangedEventHandler PropertyChanged;
   }
}