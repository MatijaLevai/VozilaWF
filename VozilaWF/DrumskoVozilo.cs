using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozilaWF
{
    abstract class DrumskoVozilo:Vozilo
    {
        public override string ToString()
        {
            return this.GetType().ToString();
        }
    }
}
