using System;
using System.Collections.Generic;
using System.Text;

namespace Marija_Bozic_Dan_54.Models
{
    public class Kamion:MotornoVozilo
    {
        public double Nosivost { get; set; }
        public double Visina { get; set; }
        public int BrojSedista { get; set; }
        public void Natovari()
        {}
        public void Istovari()
        {}

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
