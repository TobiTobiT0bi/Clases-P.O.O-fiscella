using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_12
{
    internal class Revolver {
        int posActual;
        int posBala;

        public Revolver(Random rnd) { 
            posActual = rnd.Next(0, 6);
            posBala = rnd.Next(0, 6);
        }

        public bool Disparar()
        {
            return PosActual == PosBala;
        }

        public void siguienteBala()
        {
            if (posActual == 6)
            {
                posActual = 0;
            }
            else {
                posActual++;
            }     
        }

        public int PosActual { get {  return posActual; } }

        public int PosBala { get { return posBala; } }
    }
}
