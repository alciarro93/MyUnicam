using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUnicam.Model;
using SQLite;
using Xamarin.Forms;
using MyUnicam.WinPhone.Servizi;
using Windows.Storage;
using System.IO;

[assembly: Dependency(typeof(VisiteSqlLiteWinPhone))]
namespace MyUnicam.WinPhone.Servizi
{
    public class VisiteSqlLiteWinPhone: IRepositoryVisite
    {
        private readonly SQLiteConnection conn;
        public VisiteSqlLiteWinPhone()
        {
            var DbName = "MyUnicam.db";

            var folder=Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName);      //crea il database nel path di default
            conn = new SQLiteConnection(folder);    //si connette al database
            conn.CreateTable<VisitaM>(CreateFlags.AllImplicit | CreateFlags.AutoIncPK);      //crea la tabella delle visite

        }

        public void Aggiungi(VisitaM visita)
        {
            conn.Insert(visita);
        }

        public IEnumerable<VisitaM> Elenca()     //elenca le 3 pagine più visitate
        {
            return conn.Query<VisitaM>("SELECT [Pagina], COUNT(*) FROM [VisitaM] GROUP BY [Pagina] ORDER BY COUNT(*) DESC LIMIT 3").ToList();
        }
    }
}
