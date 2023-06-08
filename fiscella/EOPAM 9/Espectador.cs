using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_9
{
    internal class Espectador
    {
        string nombre;
        int edad;
        double dinero;
        public string asiento;

        public Espectador(string nombre, int edad, double dinero)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dinero = dinero;
        }

        public double Dinero { 
            get { return dinero; }
        }

        public int Edad
        {
            get { return edad; }
        }

        public string Mostrar() {
            return $"{nombre}, {edad} años, ${dinero}";
        }
    }
}
