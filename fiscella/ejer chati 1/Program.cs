using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
¡Claro! Aquí tienes otro ejercicio un poco más desafiante:

Supongamos que deseamos crear un sistema para gestionar una tienda de libros. Para ello, debemos implementar una jerarquía de clases que incluya una clase base llamada "Libro" y dos subclases llamadas "LibroFisico" y "LibroDigital". Además, crearemos una clase ejecutable para probar el funcionamiento del sistema.

La clase base "Libro" debe tener los siguientes atributos y métodos:

Atributos:
- Título (cadena de caracteres)
- Autor (cadena de caracteres)
- Año de publicación (entero)
- Precio (número decimal)

Métodos:
- Constructor: recibe el título, autor, año de publicación y precio del libro.
- Métodos get para cada atributo.

La subclase "LibroFisico" debe heredar de "Libro" e incluir los siguientes atributos y métodos adicionales:

Atributos:
- Peso (número decimal)

Métodos:
- Constructor: recibe el título, autor, año de publicación, precio y peso del libro físico.
- Método get para el peso.

La subclase "LibroDigital" también hereda de "Libro" y agrega los siguientes atributos y métodos:

Atributos:
- Formato (cadena de caracteres)
- Tamaño del archivo (número decimal)

Métodos:
- Constructor: recibe el título, autor, año de publicación, precio, formato y tamaño del archivo del libro digital.
- Métodos get para el formato y el tamaño del archivo.

La clase ejecutable realizará lo siguiente:

1. Creará un array de libros de tamaño variable.
2. Permitirá al usuario ingresar datos para crear libros físicos y digitales.
3. Mostrará un menú para que el usuario seleccione la opción de:
   - Agregar un libro físico al array.
   - Agregar un libro digital al array.
   - Mostrar la información de todos los libros en el array. panqueques
   - Salir del programa.
4. Si el usuario selecciona "Agregar un libro físico" o "Agregar un libro digital", se le pedirán los datos correspondientes y se creará el objeto correspondiente para agregarlo al array.
5. Si el usuario selecciona "Mostrar la información de todos los libros", se recorrerá el array y se mostrará la información de cada libro, incluyendo los atributos específicos de los libros físicos y digitales.
6. El programa continuará mostrando el menú hasta que el usuario seleccione "Salir del programa".

Este ejercicio te permitirá practicar la implementación de una jerarquía de clases con subclases que tienen atributos y métodos adicionales. Además, te desafiará a crear una interfaz de usuario simple para interactuar
con el sistema de gestión de libros. */

namespace ejer_chati_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Libro> libros = new List<Libro>();
            Menu menu = new Menu();


            string[] MenuPrincipal = {
                "1. Agregar un libro fisico al array",
                "2. Agregar un libro digital al array",
                "3. Mostrar la informacion de todos los libros en el array",
                "4. salir del programa"
            };

            int pos = 0;

            menu.Crear(MenuPrincipal);

            while (true) {
                int seleccion = menu.movilidad(pos, MenuPrincipal);

                if (seleccion == 0) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese titulo: ");
                    Console.ResetColor();
                    string titu = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese autor: ");
                    Console.ResetColor();
                    string autor = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese año de publicacion: ");
                    Console.ResetColor();
                    int añoPubli = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese precio: ");
                    Console.ResetColor();
                    float precio = Convert.ToSingle(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese peso: ");
                    Console.ResetColor();
                    float peso = Convert.ToSingle(Console.ReadLine());

                    libros.Add(new LibroFisico(titu, autor, añoPubli, precio, peso));

                    Console.Clear();
                    menu.Crear(MenuPrincipal);
                }
                if (seleccion == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese titulo: ");
                    Console.ResetColor();
                    string titu = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese autor: ");
                    Console.ResetColor();
                    string autor = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese año de publicacion: ");
                    Console.ResetColor();
                    int añoPubli = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese precio: ");
                    Console.ResetColor();
                    float precio = Convert.ToSingle(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese formato: ");
                    Console.ResetColor();
                    string formato = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ingrese tamaño del archivo: ");
                    Console.ResetColor();
                    float tamaño = Convert.ToSingle(Console.ReadLine());

                    libros.Add(new LibroDigital(titu, autor, añoPubli, precio, formato, tamaño));

                    Console.Clear();
                    menu.Crear(MenuPrincipal);
                }
                if (seleccion == 2) {
                    Console.Clear();
                    if (libros.Count == 0)
                    {
                        Console.WriteLine("No hay libros (por ahora)");
                    }
                    else {
                        foreach (Libro libro in libros)
                        {
                            libro.Mostrar();
                        }
                    }
                    
                    Console.ReadKey(true);
                    Console.Clear();
                    menu.Crear(MenuPrincipal);
                }
                if (seleccion == 3) {
                    break;
                }
            }
        }
    }
}
