using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
    public  class ElectricMotor:Motor
    {
        public ElectricMotor(Snaga snaga)
        {
            VrstaGoriva = Gorivo.struja;//podrazumevana vrednost 
            SnagaAuta = snaga;
            IzracunajSnaguMotora();
        }
        public override string ToString()
        {
            return base.ToString();
        }
       
    }
}
