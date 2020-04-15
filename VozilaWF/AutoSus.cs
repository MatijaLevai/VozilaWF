using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
     public class AutoSus:Auto
    {
        public AutoSus(VrstaAuta vrsta, VrstaMenjaca menjac,SusMotor.Standard standard, SusMotor.Gorivo gorivo, Motor.Snaga snaga)
        {
            Id = Auto.brojObjekata;
            Vrsta = vrsta;
            Menjac = menjac;
            Motor = new SusMotor(standard, gorivo,snaga);
            Auto.brojObjekata++;
        }
       

        
    }
}
