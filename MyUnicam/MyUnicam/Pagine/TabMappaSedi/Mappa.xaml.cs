using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyUnicam.Pagine.TabMappaSedi
{
    public partial class Mappa : ContentPage
    {
        public Mappa()
        {
            InitializeComponent();
            // Posizionamento sopra a Camerino
            MappaSedi.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(43.135398, 13.067674), Distance.FromKilometers(1)));
            // Pin di prova
            string[] Sedi = new string [] {"Scuola di Specializzazione in Diritto Civile",
                                           "Facoltà di Giurisprudenza",
                                           "Dipartimento di Scienze Morfologiche",
                                           "Dipartimento di Fisica",
                                           "Polo D'Avack",
                                           "Plesso di Matematica",
                                           "Dipartimento di Chimica",
                                           "Facoltà di Architettura",
                                           "Polo di Alta Formazione",
                                           "Polo delle Scienze (Ex Rettorato)",
                                           "Facoltà di Scienze Tecnologiche",
                                           "Facoltà di Scienze e Tecnologie",
                                           "Dipartimento di Scienze della Terra",
                                           "Polo Carla Ludovici",
                                           "Dipartimento di Botanica ed Ecologia",
                                           "Facoltà di Architettura",
                                           "Facoltà di Architettura",
                                           "Facoltà di Medicina Veterinaria",
                                           "Centro Culturale Benedetto XIII",
                                           "Dipartimento Medicina Sperimentale",
                                           "Polo Tecnologico",
                                           "Polo Didattico Campus"
            };
            string[] Indirizzi = new string [] {"Polo Granelli, Camerino",
                                                "Palazzo Ducale, Via Cavour 2, Camerino",
                                                "Via Gentile III da Varano, Camerino",
                                                "Via Madonna delle carceri 9, Camerino",
                                                "Camerino", //D'Avack
                                                "Via Madonna delle carceri, Camerino",
                                                "Via San Agostino 1, Camerino",
                                                "Sede di Largo Cattaneo, Ascoli Piceno",
                                                "Via Camillo Lili 55, Camerino",
                                                "Via Gentile III da Varano, Camerino",
                                                "Lungomare Scipioni 6, San Benedetto del Tronto",
                                                "Via P. Mazzoni 2, Ascoli Piceno",
                                                "Via Gentile III da Varano, Camerino",
                                                "Via Madonna delle carceri, Camerino",
                                                "Via Pontoni, Camerino",
                                                "Sede di Lungo Castellano, Ascoli Piceno",
                                                "Sede Annunziata, Ascoli Piceno",
                                                "San Sollecito, Via Circonv.ne 93/95, Matelica",
                                                "Via le Mosse 1, Camerino",
                                                "Via Madonna delle Carceri, Camerino",
                                                "Palazzo Battibocca, Camerino",
                                                "Via A. D'Accorso, Camerino",
            };
            Double[] Latitudine = new Double [] { 43.133487,
                                                  43.135618,
                                                  43.140495,
                                                  43.139759,
                                                  43.138397,
                                                  43.140017,
                                                  43.138389,
                                                  42.852204,
                                                  43.133297,
                                                  43.140195,
                                                  42.934578,
                                                  42.851047,
                                                  43.139700,
                                                  43.139607,
                                                  43.136784,
                                                  42.849998,
                                                  42.851689,
                                                  43.259412,
                                                  43.143826,
                                                  43.139223,
                                                  43.136992,
                                                  43.147216,
            };
            Double[] Longitudine = new Double[] { 13.066274,
                                                  13.068457,
                                                  13.067432,
                                                  13.067572,
                                                  13.068173,
                                                  13.068430,
                                                  13.069825,
                                                  13.582238,
                                                  13.064750,
                                                  13.067089,
                                                  13.892745,
                                                  13.573059,
                                                  13.065929,
                                                  13.068772,
                                                  13.070736,
                                                  13.574883,
                                                  13.571997,
                                                  13.011941,
                                                  13.084308,
                                                  13.067056,
                                                  13.069770,
                                                  13.066391
            };
            for (int i = 0; i < Longitudine.GetLength(0); i++)
            {
                var Position = new Position(Latitudine[i], Longitudine[i]); // Latitudine, Longitudine
                var Pin = new Pin
                {
                    
                    Type = PinType.SearchResult,
                    Position = Position,
                    Label = Sedi[i],
                    Address = Indirizzi[i]  
                };
                MappaSedi.Pins.Add(Pin);
            }
        }
    }
}
