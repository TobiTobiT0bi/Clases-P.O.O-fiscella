using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_14
{
    internal class noPerecedero : Producto
    {
        string tipo;

        public noPerecedero(string nombre, int precio, string tipo) : base(nombre, precio) {
            this.tipo = tipo;   
        }

        public override string ToString()
        {
            return base.ToString() + $", tipo: {tipo}"; 
        }

        public override int Calcular() { return base.Calcular(); }
    }
}
