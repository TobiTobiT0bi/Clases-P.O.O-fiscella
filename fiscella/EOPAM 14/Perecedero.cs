using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_14
{
    internal class Perecedero : Producto
    {
        int diasACaducar;

        public Perecedero(string nombre, int precio, int dias) : base(nombre, precio){ 
            diasACaducar = dias;
        }

        public override string ToString()
        {
            return base.ToString() + $", Dias para caducar: {diasACaducar}";
        }

        public override int Calcular() {
            if (diasACaducar == 3)
            {
                Precio = Precio / 2;
            }
            else if (diasACaducar == 2)
            {
                Precio = Precio / 3;
            }
            else if (diasACaducar == 1) {
                Precio = Precio / 4;
            }

            return Precio;
        }
    }
}
