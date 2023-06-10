using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_13
{
    internal class Repartidor : Empleado
    {

        string zona;

        public Repartidor(string nombre, int edad, int salario, string zona) : base(nombre, edad, salario)
        {
            this.zona = zona;
        }

        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        public override void plus()
        {
            if (this.Edad < 25 && zona == "zona 3")
            {
                Salario += PLUS;
                Pluseado = true;
            }
        }

        public override string Mostrar()
        {
            return Pluseado == false ? base.Mostrar() + $", zona: {zona}" : base.Mostrar() + $", zona: {zona}, se ha aplicado el PLUS";
        }
    }
}
