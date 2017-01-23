using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyUnicam.Model;
using Foundation;
using UIKit;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(MyUnicam.iOS.Servizi.VisiteSqlLiteIOS))]
namespace MyUnicam.iOS.Servizi
{
    public class VisiteSqlLiteIOS : IRepositoryVisite
    {
        private readonly SQLiteConnection conn;

        public VisiteSqlLiteIOS()
        {
            string DbName = "MyUnicam.db";
            string DbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(DbPath, DbName));
            conn.CreateTable<VisitaM>(CreateFlags.AllImplicit | CreateFlags.AutoIncPK);
        }

        public void Aggiungi(VisitaM visita)
        {
            conn.Insert(visita);        //inserisce nel db la visita effettuata
        }

        public IEnumerable<VisitaM> Elenca()     //elenca le 3 pagine più visitate
        {
            return conn.Query<VisitaM>("SELECT [Pagina], COUNT(*) FROM [VisitaM] GROUP BY [Pagina] ORDER BY COUNT(*) DESC LIMIT 3").ToList();
        }

    }
}