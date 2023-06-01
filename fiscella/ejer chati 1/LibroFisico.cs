using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_chati_1
{
    internal class LibroFisico : Libro
    {
        float peso;

        public LibroFisico(string titu, string autor, int añoPubli, float precio, float peso) : base(titu, autor, añoPubli, precio)
        {
            this.peso = peso;
        }

        public override void Mostrar() {
            base.Mostrar();
            Console.WriteLine($"Libro Fisico = Peso: {Peso}kg");
        }

        public float Peso
        {
            get { return peso; }
        }
    }
}
