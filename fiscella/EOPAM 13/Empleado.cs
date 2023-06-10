using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_13
{
    internal abstract class Empleado
    {
        string nombre;
        int edad;
        int salario;
        const int PLUs = 300;
        bool pluseado = false;

        public Empleado(string nombre, int edad, int salario) { 
            this.nombre = nombre;
            this.edad = edad;
            this.salario = salario;
        }

        public string Nombre { 
            get { return nombre; } set { nombre = value; }
        }

        public int Edad { 
            get { return edad; } set { edad = value; }
        }

        public int Salario { 
            get { return salario; } set { salario = value; }
        }

        public int PLUS { 
            get { return PLUs; }
        }

        public bool Pluseado { 
            get { return pluseado; } set {  pluseado = value; }
        }


        public abstract void plus();

        public virtual string Mostrar() {
            string msj = $"nombre: {nombre}, edad: {edad}, salario: {salario}";

            return msj;
        }
    }
}
