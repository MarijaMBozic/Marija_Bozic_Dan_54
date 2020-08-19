using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Marija_Bozic_Dan_54.Models
{
    public class Automobil:MotornoVozilo
    {
        public string RegOznaka { get; set; }
        public int BrojVrata { get; set; }
        public int ZapreminaRezeorvara { get; set; }
        public string TipPrenosa { get; set; }
        public string Proizvodjac { get; set; }
        public int BrojSaobracajne { get; set; }
        public int TrenutnoStanjeGoriva { get; set; }
        public bool AutomobilNaSemaforu { get; set; }

        public EventWaitHandle _auto = new AutoResetEvent(false);

        public void Prefarbaj()
        { }

        public override void Kreni()
        {
            AutomobilNaSemaforu = false;
           if(TrenutnoStanjeGoriva>0)
            {
                _auto.Set();
                Console.WriteLine("Zeleno svetlo za automobil {0}", Proizvodjac);
            }
        }

        public override void Zaustavi()
        {
            if(TrenutnoStanjeGoriva>0)
            {
                Console.WriteLine("Crveno svetlo za automobil {0}", Proizvodjac);
            }            
            _auto.WaitOne();           
        }

        public override void Potrosnja()
        {
            if(TrenutnoStanjeGoriva>0)
            {
                Random rnd = new Random();
                TrenutnoStanjeGoriva -= rnd.Next(1, 10);
                Console.WriteLine("Trenutno stanje goriva za automobil {0} je {1}", Proizvodjac, TrenutnoStanjeGoriva);
            }         
        }

        public void SipajGorivo()
        {
            TrenutnoStanjeGoriva = ZapreminaRezeorvara;
        }
    }
}
