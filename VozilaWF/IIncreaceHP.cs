using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
    //Deklaracija interfejsa ista je kao deklaracija klase, 
    //ali ne sadrži implementaciju svojih članova pošto su svi oni implicitno apstraktni.
    //Te članove će implementirati klase i strukture koje implementiraju interfejs.
    //Interfejs može da sadrži samo metode, svojstva, događaje i indeksere,
    //koji su – ne slučajno – baš članovi klase koja može da bude apstraktna. 
    //Članovi interfejsa su uvek implicitno javni i ne mogu deklarisati modifikator pristupa.
    //Implementiranje interfejsa znači obezbeđivanje public implementacije za sve njegove članove
    public interface IIncreaceHP
    {

        bool PovecajSnagu();
    }
}
