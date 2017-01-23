using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnicam.Model
{
    /*Elencare i Video di YouTube*/
    public interface IRepositoryVideo
    {
        Task<IEnumerable<VideoM>> Elenca();
    }

    /*Elenca e aggiunge le pagine visitate dal menu*/
    public interface IRepositoryVisite
    {
        IEnumerable<VisitaM> Elenca();
        void Aggiungi(VisitaM visita);
    }

    //Espone 3 metodi per elencare le informazioni di unicam
    public interface IRepositoryInformazioni
    {
        Task<List<CSM>> ElencaCS();
        Task<List<EventiM>> ElencaEventi();
        Task<List<RubricaM>> ElencaRubrica();
    }

    // Lingua
    public interface ILocale
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(string value);
    }
}
