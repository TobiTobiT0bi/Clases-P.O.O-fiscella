using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_17
{
    internal abstract class Baraja
    {
        int pos = 0;

        public abstract void crearBaraja();

        public abstract void mostrarBaraja();

        public int Posicion
        {
            get { return pos; }
        }
    }
}
