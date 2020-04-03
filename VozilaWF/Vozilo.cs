using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
    abstract class Vozilo
    {
        protected int BrojTockova { get; set; }
        protected int BrojSedista { get; set; }
        protected int Nosivost { get; set; }

            
        public override string ToString()
        {
            return this.GetType().ToString();
        }
    }
}

        
   


/*public class Vozilo //klasa vozilo je nadklasa klasa autobus i kamion te ona ima svojstva zajednicka za te klase
        {
        public class Autobus : Vozilo,Prepravka
        {
            
            public ModelAutobusa Model;

            public Autobus(ModelAutobusa model):base()//konstruktor klase autobus ima parametr modela autobusa
            {
                Model = model;
                SpecifikacijaNaOsnovuModela();//poziva se metoda koja ce na osnovu parametra da izvrsi specifikaciju motora koji je poterban za vozilo
            }
            public enum ModelAutobusa
            { 
                A5374CNG,
                A537,
                A5375
            }
            private void SpecifikacijaNaOsnovuModela()
            {//pomocu switch case grananja mozemo u zavisnoti od modela da kreiramo drugaciji objekat klase motor
                switch (Model)
                {
                    case ModelAutobusa.A5374CNG:
                        Naziv = "Gradski";
                        this.MotorVozila = new Motor(Motor.EUstandard.EU4, Motor.VrstaGoriva.plin, 8300, 209, 280);
                        break;
                    case ModelAutobusa.A537:
                        Naziv = "Gradski";
                        this.MotorVozila = new Motor(Motor.EUstandard.EU3, Motor.VrstaGoriva.benzin, 11000, 190, 260);
                        break;
                    case ModelAutobusa.A5375:
                        Naziv = "Gradski niskopodni";
                        this.MotorVozila = new Motor(Motor.EUstandard.EU5, Motor.VrstaGoriva.dizel, 11970, 230, 299);
                        break;
                }

            }
            public string Cipovanje()
            {

                //metoda za unapredjivanje specifikacija motora auta.
                //izvrsavanje metode zavisi od tipa auta i da li je vec cipovan
                if (Cipovan)
                    return "Vas Autobus je vec cipovan. Nije preporucljivo dodatno povecavanje snage.";
              
                        Cipovan = MotorVozila.PovecajSnaguMotora();//ukoliko je moguce povecati snagu motora ona ce biti povecana za 30%
                        if (Cipovan)//ukoliko je uspelo cipovanje povratna vrednost ce biti specifikacija motora
                        { return "Vase vozilo je sad cipovan i njegove specifikacije su: " + MotorVozila.ToString(); }
                        else { return "Za zadato vozilo nije moguce obaviti cipovanje jer nije definisan kako je predvidjeno."; }

                
            }

         }
        
        public class Kamion : Vozilo,Prepravka//klasa kamion je slicna klasi autobus te mislim da nij epotrebno dodatno objasnjenje
        {

            public ModelKamiona Model;

            public Kamion(ModelKamiona model) : base()
            {
                Model = model;
                SpecifikacijaNaOsnovuModela();
            }

            public string Cipovanje()
            {
                //metoda za unapredjivanje specifikacija motora auta.
                //izvrsavanje metode zavisi od tipa auta i da li je vec cipovan
                if (Cipovan)
                    return "Vas Kamion je vec cipovan. Nije preporucljivo dodatno povecavanje snage.";

                Cipovan = MotorVozila.PovecajSnaguMotora();//ukoliko je moguce povecati snagu motora ona ce biti povecana za 30%
                if (Cipovan)//ukoliko je uspelo cipovanje povratna vrednost ce biti specifikacija motora
                { return "Vase vozilo je sad cipovan i njegove specifikacije su: " + MotorVozila.ToString(); }
                else { return "Za zadato vozilo nije moguce obaviti cipovanje jer nije definisan kako je predvidjeno."; }


                
            }

            private void SpecifikacijaNaOsnovuModela()
            {
                Naziv = Model.ToString();
                switch (Model)
                {
                    case ModelKamiona.Sanducar:
                        this.MotorVozila = new Motor(Motor.EUstandard.EU5, Motor.VrstaGoriva.dizel, 8900, 265, 360);
                        break;
                    case ModelKamiona.Tegljac:
                        this.MotorVozila = new Motor(Motor.EUstandard.EU5, Motor.VrstaGoriva.benzin, 11970, 295, 401);
                        break;
                    case ModelKamiona.Kiper:
                        this.MotorVozila = new Motor(Motor.EUstandard.EU5, Motor.VrstaGoriva.benzin, 11970, 295, 401);
                        break;
                    case ModelKamiona.Vojni:
                        this.MotorVozila = new Motor(Motor.EUstandard.EU3, Motor.VrstaGoriva.dizel, 11970, 295, 401);
                        break;
                }
            }

            public enum ModelKamiona
            {
                Sanducar,
                Tegljac,
                Kiper,
                Vojni
            }

        }
 */
