using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUnicam.Messaggi;
using Xamarin.Forms;
using MyUnicam.Risorse;
using MyUnicam.Pagine;

namespace MyUnicam.Model
{
    public class PaginaM : INotifyPropertyChanged
    {
        public Type TipoPagina { get; private set; }
        public string NomePagina { get;  set; }
        public string IconaPagina { get; private set; } //Identificatore necessario per selezionare l'icona della pagina
        public string Codice { get; private set; }

        //costruttore pagina passando un tipo
        public PaginaM(Type tipoPagina)
        {
            //controlla che il valora passato faccia parte dele namespace corretto
            if (tipoPagina.Namespace != "MyUnicam.Pagine")
                throw new Exception("Il tipo fornito deve essere quello di una pagina");

            this.NomePagina = Dizionario.ResourceManager.GetString(tipoPagina.Name, Dizionario.Culture);
            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs("NomePagina"));  
       
            this.TipoPagina = tipoPagina;
            // L'aggiunta del .png è necessaria per il caricamento delle immagini su WP
            this.IconaPagina = tipoPagina.Name + ".png";
        }

        //costruttore pagina con tipo e una stringa
        public PaginaM(Type tipoPagina, string codice)
        {
            //controlla che il valora passato faccia parte dele namespace corretto
            if (tipoPagina.Namespace != "MyUnicam.Pagine")
                throw new Exception("Il tipo fornito deve essere quello di una pagina");
            if (tipoPagina == typeof(CorsiLaurea))
            {
                #region NOME IN BASE AL CODICE
                if (codice == "'L1','L2'")
                {
                    this.NomePagina = Dizionario.ResourceManager.GetString("triennale", Dizionario.Culture);
                }
                else if (codice == "'LS','LM'")
                {
                    this.NomePagina = Dizionario.ResourceManager.GetString("magistrale", Dizionario.Culture);
                }
                else if (codice == "'LC5','LC6','LM6','LM5'")
                {
                    this.NomePagina = Dizionario.ResourceManager.GetString("magunico", Dizionario.Culture);
                }
                else if (codice == "'M1'")
                {
                    this.NomePagina = Dizionario.ResourceManager.GetString("primomaster", Dizionario.Culture);
                }
                else if (codice == "'M2'")
                {
                    this.NomePagina = Dizionario.ResourceManager.GetString("secondomaster", Dizionario.Culture);
                }
                else if (codice == "'SP2','SP3','S4','SP5','SP6','S1','SHSP','CSS'")
                {
                    this.NomePagina = Dizionario.ResourceManager.GetString("specialistica", Dizionario.Culture);
                }
                else if (codice == "'D1','D2'")
                {
                    this.NomePagina = Dizionario.ResourceManager.GetString("dottorato", Dizionario.Culture);
                }
                else if (codice == "'TFA'")
                {
                    this.NomePagina = Dizionario.ResourceManager.GetString("tfa", Dizionario.Culture);
                }
                #endregion
            }
            else
            {
                this.NomePagina = Dizionario.ResourceManager.GetString(tipoPagina.Name, Dizionario.Culture);
            }
            
            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs("NomePagina"));

            this.TipoPagina = tipoPagina;
            this.IconaPagina = tipoPagina.Name + ".png";
            this.Codice = codice;
        }

        public override string ToString()
        {
            return NomePagina;
        }
        public string GetCodice()
        {
            return Codice;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
