using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
    public abstract class Auto
    {
        public static int brojObjekata = 0;

        public int Id { get; protected set; }
        public VrstaAuta Vrsta { get; protected set; }
        public VrstaMenjaca Menjac { get; protected set; }
        
        public Motor Motor{ get; set; }
        public enum VrstaAuta
        {
            limunzina,
            hecbek,
            kabriolet,
            minivan,
            karavan
        }
        public enum VrstaMenjaca
        {
            manuelni,
            automatski
        }
        public override string ToString()
        {
            return "Auto tipa: " + Vrsta.ToString() + ", sa menjačem koji je " + Menjac.ToString() + " i motorm sa : "+Motor.ToString();
        }
    }
}
