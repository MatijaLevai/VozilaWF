using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
     class AutoSus : MotornoVozilo, IPrepravka
    {
        

        public int BrojVrata { get; private set; }
        public VrstaMenjaca Menjac { get; private set; }
        public VrstaAuta Vrsta{get; private set; }
        public bool Cipovan { get;private set; }
        public SusMotor Motor { get; private set; }

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
        public AutoSus(VrstaAuta vrsta,int brojVrata, VrstaMenjaca menjac,SusMotor.Gorivo gorivo, int prosecnaPotrosnja, int snagaKW, int snagaKS, int zapremina, bool cipovan)
        {
            Vrsta = vrsta;
            BrojVrata = brojVrata;
            Menjac = menjac;
            Cipovan = cipovan;
            Motor = new SusMotor(gorivo, prosecnaPotrosnja, snagaKW, snagaKS, zapremina);
            

        }



        public string[] Ispis()
        {
            string[] ispis = new string[9];
            ispis[0] = Vrsta.ToString();
            ispis[1] = BrojVrata.ToString();
            ispis[2] = Menjac.ToString();
            
            if(Cipovan)
            ispis[3]="je izvrseno";//ukoliko je Cipovan == true
            ispis[3] = "nije izvrseno";//ukoliko je Cipovanje == false
            string[] s = Motor.Ispis();
            ispis[4] = s[0];
            ispis[5] = s[1];
            ispis[6] = s[2];
            ispis[7] = s[3];
            ispis[8] = s[4];
            return ispis;
         }

        public string Cipovanje()
        {

            //metoda za unapredjivanje specifikacija motora auta.
            //izvrsavanje metode zavisi od tipa auta i da li je vec cipovan
            if (Cipovan)
                return "Vas Auto je vec cipovan. Nije preporucljivo dodatno povecavanje snage.";

            Cipovan = Motor.PovecajSnaguMotora();//ukoliko je moguce povecati snagu motora ona ce biti povecana za 30%
            if (Cipovan)//ukoliko je uspelo cipovanje povratna vrednost ce biti specifikacija motora
           return "Vase vozilo je sad cipovan i njegove specifikacije su: " + Motor.ToString(); 
           return "Za zadato vozilo nije moguce obaviti cipovanje jer nije definisan kako je predvidjeno."; 


        }
    }
}
