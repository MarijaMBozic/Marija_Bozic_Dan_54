using Marija_Bozic_Dan_54.Models;
using System;
using System.Collections.Generic;

namespace Marija_Bozic_Dan_54
{
    class Program
    {
        static void Main(string[] args)
        {
            Kamion kamion1 = InicializationKamion(3000,5000, "D", "Disel", "Plava", 123, 30000, 3, 3);
            Kamion kamion2 = InicializationKamion(2500, 5000, "C", "Disel", "Zuta", 456, 25000, 3, 2);
            Dictionary<int, Kamion> kamioni = new Dictionary<int, Kamion>();
            kamioni.Add(kamion1.BrojMotora, kamion1);
            kamioni.Add(kamion2.BrojMotora, kamion2);

            Traktor traktor1 = InicializationTraktor(2500,6000,"F","Disel", "Crvena", 741, 30, 2, "prednji tockovi");
            Traktor traktor2 = InicializationTraktor(2500, 6000, "F", "Disel", "Zuta", 753, 25, 2, "zadnji tockovi");
            HashSet<Traktor> traktori = new HashSet<Traktor>();
            traktori.Add(traktor1);
            traktori.Add(traktor2);

            Automobil automobil1 = InicializationAutomobil(1400, 1000, "B", "Benzin", "Zuta", 999, "NS123", 5, 50, "manuelni", "Fiat", 123);
            Automobil automobil2 = InicializationAutomobil(1500, 1200, "B", "Disel", "Crvena", 789, "NS321", 3, 55, "manuelni", "Punto", 321);
            Automobil automobil3 = InicializationAutomobil(1600, 1300, "B", "Benzin", "Plava", 858, "NS741", 4, 60, "manuelni", "Opel", 741);
            Automobil automobil4 = InicializationAutomobil(1700, 1400, "B", "Disel", "Crvena", 969, "NS852", 3, 65, "manuelni", "BMW", 147);
            Automobil automobil5 = InicializationAutomobil(1800, 1600, "B", "Benzin", "Narandzasta", 656, "NS353", 4, 70, "manuelni", "Audi", 963);
            List<Automobil> automobili = new List<Automobil>();
            automobili.Add(automobil1);
            automobili.Add(automobil2);
            automobili.Add(automobil3);
            automobili.Add(automobil4);
            automobili.Add(automobil5);

        }

        public static Kamion InicializationKamion(double zapreminaMotora, int tezina, string kategorija,
            string tipMotora, string boja, int brojMotora, double nosivost, double visina, int brojSredista)
        {
            Kamion kamion = new Kamion();
            kamion.BrojMotora = brojMotora;
            kamion.Tezina = tezina;
            kamion.ZapreminaMotora = zapreminaMotora;
            kamion.Kategorija = kategorija;
            kamion.TipMotora = tipMotora;
            kamion.Boja = boja;
            kamion.Nosivost = nosivost;
            kamion.Visina = visina;
            kamion.BrojSedista = brojSredista;

            return kamion;
        }

        public static Traktor InicializationTraktor(double zapreminaMotora, int tezina, string kategorija,
            string tipMotora, string boja, int brojMotora, double velicinaGume, int osovinskiRazmak, string pogon)
        {
            Traktor traktor = new Traktor();
            traktor.BrojMotora = brojMotora;
            traktor.Tezina = tezina;
            traktor.ZapreminaMotora = zapreminaMotora;
            traktor.Kategorija = kategorija;
            traktor.TipMotora = tipMotora;
            traktor.Boja = boja;
            traktor.VelicinaGuma = velicinaGume;
            traktor.OsovinskiRazmak = osovinskiRazmak;
            traktor.Pogon = pogon;

            return traktor;
        }

        public static Automobil InicializationAutomobil(double zapreminaMotora, int tezina, string kategorija,
                                                     string tipMotora, string boja, int brojMotora, string registarskaOznaka, 
                                                     int brojVrata, int zapreminaRezeorvara, string tipPrenosa, string proizvodjac,  
                                                     int brojSaobracajne)
        {
            Automobil automobil = new Automobil();
            automobil.BrojMotora = brojMotora;
            automobil.Tezina = tezina;
            automobil.ZapreminaMotora = zapreminaMotora;
            automobil.Kategorija = kategorija;
            automobil.TipMotora = tipMotora;
            automobil.Boja = boja;
            automobil.RegOznaka = registarskaOznaka;
            automobil.BrojVrata = brojVrata;
            automobil.ZapreminaRezeorvara = zapreminaRezeorvara;
            automobil.TipPrenosa = tipPrenosa;
            automobil.Proizvodjac = proizvodjac;
            automobil.BrojSaobracajne = brojSaobracajne;

            return automobil;
        }
    }
}
