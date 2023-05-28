using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_8
{
    internal class Persona
    {
        public string nombre;
        public int edad;
        public string sexo;
        public bool falta = false;

        public string[] nombresPanqueques = { "Abbott", "Acosta", "Adan", "Adkins", "Aguilar", "Abby", "Abigail", "Adele", "Aaron", "Abdul", "Abe", "Abel", "Abraham", "Adam", "Adan", "Adolfo", "Adolph", "Adrian", "John", "Paul", "Ringo", "George" };
        public string[] sexos = { "Masculino", "Femenino" };

        public Persona(Random rnd) 
        {
            sexo = sexos[rnd.Next(0, sexos.Length)];
            nombre = nombresPanqueques[rnd.Next(0, nombresPanqueques.Length)];
            falta = Falta(rnd);
        }

        public virtual bool Falta(Random rnd) {
            bool falta = Convert.ToBoolean(rnd.Next(0, 2));

            return falta;
        }
    }
}
