using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyUnicam.Model;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(MyUnicam.Droid.Servizi.VisiteSqlLiteDroid))]
namespace MyUnicam.Droid.Servizi
{
    public class VisiteSqlLiteDroid : IRepositoryVisite
    {
        private readonly SQLiteConnection conn;
        public VisiteSqlLiteDroid()
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

        public IEnumerable<VisitaM> Elenca()     //elenca le 3 pagine piÅEvisitate
        {
            return conn.Query<VisitaM>("SELECT [Pagina], COUNT(*) FROM [VisitaM] GROUP BY [Pagina] ORDER BY COUNT(*) DESC LIMIT 3").ToList();
        }
    }
}