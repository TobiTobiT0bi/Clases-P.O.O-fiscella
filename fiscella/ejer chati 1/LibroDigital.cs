using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_chati_1
{
    internal class LibroDigital : Libro
    {
        string formato;
        float tamañoArchivo;

        public LibroDigital(string titu, string autor, int añoPubli, float precio, string formato, float tamañoArchivo) : base(titu, autor, añoPubli, precio)
        {
            this.formato = formato;
            this.tamañoArchivo = tamañoArchivo;
        }

        public override void Mostrar()
        {
            base.Mostrar();
            Console.WriteLine($"Libro digital = Formato: {Formato}, Tamaño de archivo: {tamañoArchivo} Kb");
        }

        public string Formato
        {
            get { return formato; }
        }

        public float Tamaño
        {
            get { return tamañoArchivo; }
        }
    }
}
