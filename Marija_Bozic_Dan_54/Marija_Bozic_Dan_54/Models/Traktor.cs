using System;
using System.Collections.Generic;
using System.Text;

namespace Marija_Bozic_Dan_54.Models
{
    public class Traktor:MotornoVozilo
    {
        public double VelicinaGuma { get; set; }
        public int OsovinskiRazmak { get; set; }
        public string Pogon { get; set; }

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
