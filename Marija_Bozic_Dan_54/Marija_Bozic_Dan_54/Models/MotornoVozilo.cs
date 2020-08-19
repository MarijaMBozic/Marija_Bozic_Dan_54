using System;
using System.Collections.Generic;
using System.Text;

namespace Marija_Bozic_Dan_54.Models
{
    public abstract class MotornoVozilo
    {
        public double ZapreminaMotora { get; set; }
        public int Tezina { get; set; }
        public string Kategorija { get; set; }
        public string TipMotora { get; set; }
        public string Boja { get; set; }
        public int BrojMotora { get; set; }

        public abstract void Potrosnja();
        public abstract void Kreni();
        public abstract void Zaustavi();
    }
}
