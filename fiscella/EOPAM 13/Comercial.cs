using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_13
{
    internal class Comercial : Empleado
    {

        double comision;

        public Comercial(string nombre, int edad, int salario, double comision) : base(nombre, edad, salario)
        {
            this.comision = comision;
        }

        public double Comision {
            get { return comision; } set { comision = value; }
        }

        public override void plus()
        {
            if (this.Edad > 30 && comision > 200) {
                Salario += PLUS;
                Pluseado = true;
            }
        }

        public override string Mostrar()
        {
            return Pluseado == false ? base.Mostrar() + $", comision: {comision}" : base.Mostrar() + $", comision: {comision}, se ha aplicado el PLUS";
        }
    }
}
