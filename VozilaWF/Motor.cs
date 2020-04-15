using System;

namespace VozilaWF
{
    public abstract class Motor
    {
        public Gorivo VrstaGoriva { get; protected set; }
        public Snaga SnagaAuta { get; protected set; }
        public int SnagaKS { get; protected set; }
        
        

        public enum Gorivo
        {
            dizel,
            benzin,
            CNG,
            struja
        }
        public enum Snaga
        {
            kW25= 25,
            kW35= 35,
            kW44 = 44,
            kW55 = 55,
            kW66 = 66,
            kW74 = 74,
            kW80 = 80,
            kW85 = 85,
            kW96 = 96,
            kW110 = 110,
            kW147 = 147,
            kW184 = 184,
            kW222 = 222,
            kW262 = 262,
            kW294 = 294,
            kW333 = 333

        }
        public bool IzracunajSnaguMotora()
        {
            if (SnagaAuta > 0)
            {
                SnagaKS = Convert.ToInt32((int)SnagaAuta * 1.35962);//(int) je direktno koriscenje integer vrednosti enuma
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return " Snage u "+SnagaAuta + ", Konjskih snaga : " + SnagaKS + ", koristi " + VrstaGoriva;
        }

    }
}
