using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
    public class AutoElectric:Auto
    {
        
        public AutoElectric(VrstaAuta vrsta, VrstaMenjaca menjac, Motor.Snaga snaga)
        {
            Id = Auto.brojObjekata;
            Vrsta = vrsta; 
            Menjac = menjac;
            
            Motor = new ElectricMotor(snaga);
            Auto.brojObjekata++;
        }

    }
}
