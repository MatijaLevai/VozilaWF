using System;

namespace VozilaWF
{
    public abstract class Motor
    {
        public int SnagaKW { get;protected set; }
        public int SnagaKS { get; protected set; }
        public bool PovecajSnaguMotora()
        {
            if (SnagaKW > 0)
            {
                SnagaKW = Convert.ToInt32(SnagaKW * 1.3);
                SnagaKS = Convert.ToInt32(SnagaKW * 1.35962);
                return true;
            }
            return false;
        }

    }
}