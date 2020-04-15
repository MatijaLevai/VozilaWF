using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
    public class SusMotor : Motor
    {
        public Standard EUstandard { get; set; }
       
        public enum Standard
        {
            Euro2,
            Euro3,
            Euro4,
            Euro5
        }
        public SusMotor(Standard standard,Gorivo gorivo,Snaga snaga)
        {
            EUstandard = standard;
            VrstaGoriva = gorivo;
            SnagaAuta = snaga;
            IzracunajSnaguMotora();
        }
        public override string ToString()
        {
            return base.ToString()+", "+ EUstandard+ " standarda";
        }
       
        
    }
}
