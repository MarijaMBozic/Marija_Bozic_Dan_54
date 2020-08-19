using Marija_Bozic_Dan_54.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace Marija_Bozic_Dan_54
{
    class Program
    {
        static List<Automobil> automobili = new List<Automobil>();
        static string svetloNaSemaforu = "zeleno";

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

            Automobil automobil1 = InicializationAutomobil(1400, 1000, "B", "Benzin", "Zuta", 999, "NS123", 5, 50, "manuelni", "Fiat", 123, 50);
            Automobil automobil2 = InicializationAutomobil(1500, 1200, "B", "Disel", "Crvena", 789, "NS321", 3, 55, "manuelni", "Punto", 321, 55);
            Automobil automobil3 = InicializationAutomobil(1600, 1300, "B", "Benzin", "Plava", 858, "NS741", 4, 60, "manuelni", "Opel", 741, 60);
            Automobil automobil4 = InicializationAutomobil(1700, 1400, "B", "Disel", "Crvena", 969, "NS852", 3, 65, "manuelni", "BMW", 147, 65);                     
            automobili.Add(automobil1);
            automobili.Add(automobil2);
            automobili.Add(automobil3);
            automobili.Add(automobil4);

            Thread threadSemafor = new Thread(Semafor);
            threadSemafor.Name = "Semafor";
            threadSemafor.Start();

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 5000; 

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;

            timer.Enabled = true;

            Console.ReadLine();

        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Automobil automobil5 = InicializationAutomobil(1800, 1600, "B", "Benzin", "Narandzasta", 656, "NS353", 4, 70, "manuelni", "Golf", 963, 70);
            automobili.Add(automobil5);

            Thread thredPotrosnjaGoriva = new Thread(()=>PotrosnjaGoriva(automobili));
            thredPotrosnjaGoriva.Name = "Potrosnja goriva";
            thredPotrosnjaGoriva.Start();

            foreach (Automobil automobil in automobili)
            {
                Thread thread = new Thread(()=>PocniTrku(automobil));
                thread.Name = automobil.BrojMotora.ToString();
                thread.Start();
                Console.WriteLine("{0}", thread.Name);
            }         
        }

        private static void PosleDesetSekundi(Object source, System.Timers.ElapsedEventArgs e, Automobil auto)
        {
            Console.WriteLine("Posle 10 seklundi start");
            auto.AutomobilNaSemaforu = true;
            if (svetloNaSemaforu == "zeleno")
            {
                auto.Kreni();                
            }
            else
            {               
                ////System.Timers.Timer timer = new System.Timers.Timer();
                ////timer.Interval = 1000;
                ////timer.Elapsed += (sender, e) => PosleJedneSekundi(sender, e, auto, timer);
                ////timer.AutoReset = true;
                ////timer.Enabled = true;
                auto.Zaustavi();              
            }          
            Console.WriteLine("Posle 10 seklundi end");
        }

        //private static void PosleJedneSekundi(Object source, System.Timers.ElapsedEventArgs e, Automobil auto, System.Timers.Timer timer)
        //{
        //    Console.WriteLine("Posle 1 seklundi start");
        //    if (svetloNaSemaforu == "zeleno")
        //    {
        //        auto.Kreni();
        //        timer.Stop();
        //        Console.WriteLine("Zeleno svetlo za automobil {0}", auto.Proizvodjac);
        //    }

        //    Console.WriteLine("Posle 1 seklundi end");
        //}

        private static void Semafor()
        {
            int brojac = 27;
            while (brojac != 0)
            {
                brojac--;
                if(svetloNaSemaforu== "zeleno")
                {
                    svetloNaSemaforu = "crveno";
                }
                else
                {
                    svetloNaSemaforu = "zeleno";
                    if(automobili.Count>0)
                    {
                        foreach (Automobil automobil in automobili)
                        {
                            if(automobil.AutomobilNaSemaforu)
                            {
                                automobil.Kreni();
                            }                            
                        }
                    }
                }
                Console.WriteLine("Svetla na semaforu {0}", svetloNaSemaforu);
                Thread.Sleep(30000);
            }

            Console.WriteLine("Semafor");
        }

        private static void PotrosnjaGoriva(List<Automobil> automobili)
        {
            int brojac = 220;
            while (brojac != 0)
            {
                brojac--;
                for (int i = 0; i < automobili.Count; i++)
                {
                    automobili[i].Potrosnja();
                    if(automobili[i].TrenutnoStanjeGoriva<=0)
                    {
                        Console.WriteLine("Automobil {0} je zavrsio trku ostao je bez goriva.", automobili[i].Proizvodjac);
                        //automobili.RemoveAt(i);
                        //i--;                       
                        automobili[i].Zaustavi();
                    }
                }
                foreach (Automobil automobil in automobili)
                {
                    automobil.Potrosnja();                      
                }
                Thread.Sleep(1000);
            }
        }

        public static void PocniTrku(Automobil auto)
        {
            //Thread.Sleep(10000);            
            //auto.Zaustavi();
            //if (svetloNaSemaforu == "zeleno")
            //{
            //    auto.Kreni();
            //}

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 10000;
            timer.Elapsed += (sender, e) => PosleDesetSekundi(sender, e, auto);
            timer.AutoReset = false;
            timer.Enabled = true;
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
                                                     int brojSaobracajne, int trenutnaStanjeGoriva)
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
            automobil.TrenutnoStanjeGoriva = trenutnaStanjeGoriva;

            return automobil;
        }
    }
}
