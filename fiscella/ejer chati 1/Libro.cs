using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_chati_1
{
    internal class Libro
    {
        string titulo;
        string autor;
        int añoPubli;
        float precio;

        public Libro(string titu, string autor, int añoPubli, float precio) 
        {
            this.titulo = titu;
            this.autor = autor;
            this.añoPubli = añoPubli;
            this.precio = precio;
        }

        public virtual void Mostrar()
        {
            Console.WriteLine($"\nTitulo: {Titulo}, Autor: {Autor}, Año de publicacion: {Año}, Precio: ${Precio}");
        }

        public string Titulo{
            get { return titulo; }
        }

        public string Autor
        {
            get { return autor; }
        }

        public int Año
        {
            get { return añoPubli; }
        }

        public float Precio
        {
            get { return precio; }
        }
    }
}
