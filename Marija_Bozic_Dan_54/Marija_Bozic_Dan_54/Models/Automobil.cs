using System;
using System.Collections.Generic;
using System.Text;

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

        public void Prefarbaj()
        { }

        public override void Kreni()
        {
            throw new NotImplementedException();
        }

        public override void Zaustavi()
        {
            throw new NotImplementedException();
        }

        public override void Potrosnja()
        {
            throw new NotImplementedException();
        }
    }
}
