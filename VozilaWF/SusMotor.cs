using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
    public class SusMotor : Motor
    {
        public Gorivo VrstaGoriva { get;private set; }
        public int ProsecnaPotrosnja { get; private set; }
        public int Zapremina { get; private set; }
        public enum Gorivo
        {
            dizel,
             benzin,
             CNG
        }
        public SusMotor(Gorivo gorivo,int prosecnaPotrosnja,int snagaKW,int snagaKS,int zapremina)
        {
            VrstaGoriva = gorivo;
            ProsecnaPotrosnja = prosecnaPotrosnja;
            SnagaKW = snagaKW;
            SnagaKS = snagaKS;
            Zapremina = zapremina;
        }
        public override string ToString()
        {
            return this.GetType().ToString() + " "+this.SnagaKS+ "Konjskih snaga i " + SnagaKW + "KW, koristi "+VrstaGoriva+" ima zapreminu motora "+Zapremina+" i prosecnu potrosnju od "+ProsecnaPotrosnja;
        }
        public string[] Ispis()
        {
            string[] ispis = new string[] {
            VrstaGoriva.ToString(),
            ProsecnaPotrosnja.ToString(),
            SnagaKW.ToString(),
            SnagaKS.ToString(),
            Zapremina.ToString()
                };
            return ispis;
        }
        
    }
}
