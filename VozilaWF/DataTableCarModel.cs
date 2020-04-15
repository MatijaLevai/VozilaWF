using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
    class DataTableCarModel
    {
        public int ID { get;private set; }
        public string Tip { get; private set; }
        public string Menjac { get; private set; }
        public string EuroStandard { get; private set; }
        public string Snaga { get; private set; }
        public string Gorivo { get; private set; }
        public DataTableCarModel()
        {

        }
        public DataTableCarModel(Auto a)
        {
            ID = a.Id;
            Tip = a.Vrsta.ToString();
            Menjac = a.Menjac.ToString();
            Snaga = a.Motor.SnagaAuta.ToString();
            Gorivo = a.Motor.VrstaGoriva.ToString();
            SusMotor s = a.Motor as SusMotor;
            try { EuroStandard = s.EUstandard.ToString(); }
            catch { }
           
        }
    }
}
