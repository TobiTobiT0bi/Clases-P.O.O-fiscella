using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_15
{
    internal class Azucarada : Bebida
    {
        int porcentajeAzucar;
        bool promo;
        public Azucarada(int identificador, float cantLitros, float precio, string marca, int porcentajeAzucar, bool promo) : base(identificador, cantLitros, precio, marca) {
            this.porcentajeAzucar = porcentajeAzucar;
            this.promo = promo;
        }
        public override string Mostrar()
        {
            if (promo == true) {
                return base.Mostrar() + $", porcentaje de azucar: {porcentajeAzucar}%, promocion habilitada: {promo}, precio con promo: {base.Precio - (base.Precio / 10)}";
            }

            return base.Mostrar() + $", porcentaje de azucar: {porcentajeAzucar}%, promocion habilitada: {promo}";
        }

        public override float Precio {
            get { return promo == true ? base.Precio - (base.Precio / 10) : base.Precio; }
        }
    }
}
