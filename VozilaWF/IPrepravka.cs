using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
    //interfejs prepravka je najjednostavniji primer interfejsa gde je definisana metoda koja mora da se implementira u klasi
    // koja implementira interfejs, nije bitno kakvo ce biti telo te metode, 
    // bitno je da ona ima potpis kakav je definisan u interfejsu


    interface IPrepravka
    {
        string Cipovanje();
    }
}
