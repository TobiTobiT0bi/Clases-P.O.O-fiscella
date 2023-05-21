using System;

namespace EOPAM_6
{
    /*  
    Crear una clase Libro que contenga los siguientes atributos:
    – ISBN
    – Título
    – Autor
    – Número de páginas
    Crear sus respectivos métodos get y set correspondientes para cada atributo. Crear el método que muestre la información relativa al libro con el siguiente formato:
    «El libro con ISBN creado por el autor tiene páginas»
    En el fichero main, crear 2 objetos Libro (los valores que se quieran) y mostrarlos por pantalla.
    Por último, indicar cuál de los 2 tiene más páginas.
    */

    internal class Program
    {
        static public void atributos(Libro libro) {
            if (libro.iSBN == true)
            {
                Console.WriteLine($"«El libro '{libro.Titulo}' con ISBN creado por {libro.Autor} tiene {libro.Paginas} páginas»");
            }
            else {
                Console.WriteLine($"«El libro '{libro.Titulo}' sin ISBN creado por {libro.Autor} tiene {libro.Paginas} páginas»");
            }
        }
        static void Main(string[] args)
        {
            Libro libro1 = new Libro("Con la sangre en el ojo", "Alejandro Parisi", 168); // muy bueno
            Libro libro2 = new Libro("la divina comedia", "Dante Alighieri", 304); // un clásico

            libro2.iSBN = false;

            atributos(libro1); atributos(libro2);

            Console.ReadKey();
        }
    }
}

//panqueques