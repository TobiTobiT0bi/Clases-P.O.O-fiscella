using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_16
{
    internal class Contacto
    {
        string nombre = "";
        string telefono = "1234";

        public Contacto(string nombre, string telefono) { 
            this.nombre = nombre;
            this.telefono = telefono;
        }

        public string Nombre { get {  return nombre; } }

        public string Telefono { get { return telefono; } }

        public string Mostrar() {
            return $"Nombre: {nombre}, Telefono: {telefono}";
        }
    }
}
