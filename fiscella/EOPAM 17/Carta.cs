using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_17
{
    internal class Carta<T>
    {
        T palo;

        public Carta(T palo)
        {
            this.palo = palo;
        }

        public string MostrarPalo()
        {
            return $"{palo.ToString()}";
        }
    }
}
