using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_14
{
    internal class Producto
    {
        string nombre;
        int precio;

        public Producto(string nombre, int precio) { 
            this.nombre = nombre;
            this.precio = precio;
        }

        public string Nombre { get {  return nombre; } }

        public int Precio { get { return precio; } set { precio = value ; } }

        public new virtual string ToString() {
            return $"nombre: {nombre}, precio; {precio}";
        }

        public virtual int Calcular() {
            return precio;
        }
    }
}
