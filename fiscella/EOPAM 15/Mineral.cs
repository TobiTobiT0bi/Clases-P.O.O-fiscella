using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_15
{
    internal class Mineral : Bebida
    {
        string origen;

        public Mineral(int identificador, float cantLitros, float precio, string marca, string origen) : base(identificador, cantLitros, precio, marca)
        {
            this.origen = origen;
        }

        public override string Mostrar()
        {
            return base.Mostrar() + $", origen: {origen}";
        }

        public override float Precio
        {
            get { return base.Precio; }
        }
    }
}
