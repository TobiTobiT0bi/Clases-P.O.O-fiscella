using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
Nos piden hacer un programa orientado a objetos sobre un cine (solo de una sala) tiene un conjunto de asientos (8 filas por 9 columnas, por ejemplo).
Del cine nos interesa conocer la película que se está reproduciendo y el precio de la entrada en el cine.
De las películas nos interesa saber el título, duración, edad mínima y director.
Del espectador, nos interesa saber su nombre, edad y el dinero que tiene.
Los asientos son etiquetados por una letra (columna) y un número (fila), la fila 1 empieza al final de la matriz como se muestra en la tabla. También deberemos saber si está ocupado o no el asiento.
8 A 8 B 8 C 8 D 8 E 8 F 8 G 8 H 8 I
7 A 7 B 7 C 7 D 7 E 7 F 7 G 7 H 7 I
6 A 6 B 6 C 6 D 6 E 6 F 6 G 6 H 6 I
5 A 5 B 5 C 5 D 5 E 5 F 5 G 5 H 5 I
4 A 4 B 4 C 4 D 4 E 4 F 4 G 4 H 4 I
3 A 3 B 3 C 3 D 3 E 3 F 3 G 3 H 3 I
2 A 2 B 2 C 2 D 2 E 2 F 2 G 2 H 2 I
1 A 1 B 1 C 1 D 1 E 1 F 1 G 1 H 1 I
Realizaremos una pequeña simulación, en el que generamos muchos espectadores y los sentamos aleatoriamente (no podemos donde ya esté ocupado).
En esta versión sentaremos a los espectadores de uno en uno.
Solo se podrá sentar si tienen el suficiente dinero, hay espacio libre y tiene edad para ver la película, en caso de que el asiento esté ocupado le buscamos uno libre.
Los datos del espectador y la película pueden ser totalmente aleatorios.
 
 */
namespace EOPAM_9
{
    internal class Program
    {
        static void crearPantalla(List<Asiento> asientos) {
            List<Asiento> filas = new List<Asiento>();

            for (int i = 8; i > 0; i--) {
                filas = asientos.FindAll(p => p.Fila == i);

                Console.SetCursorPosition(8, 18 - i);
                for (int j = 0; j < filas.Count(); j++) {
                    if (filas[j].ocupado == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(filas[j].coordenadasAString() + " ");
                        Console.ResetColor();
                    }
                    else 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(filas[j].coordenadasAString() + " ");
                        Console.ResetColor();
                    }
                    
                }
            }
            
        }

        static void Main(string[] args)
        {
            int disponibles;

            List<Asiento> asientos = new List<Asiento>();
            List<Espectador> espectadores = new List<Espectador>();
            Random rnd = new Random();
            string[] nombres = { "Abbott", "Acosta", "Adams", "Adkins", "Aguilar", "Abby", "Abigail", "Adele", "Aaron", "Abdul", "Abe", "Abel", "Abraham", "Adam", "Adan", "Adolfo", "Adolph", "Adrian", "John", "Paul", "Ringo", "George" };

            List<Pelicula> pelis = new List<Pelicula>();

            pelis.Add(new Pelicula("El padrino", rnd.Next(60, 180) + rnd.NextDouble(), rnd.Next(0, 19), "Francis Ford Coppola"));
            pelis.Add(new Pelicula("Iron Man", rnd.Next(60, 180) + rnd.NextDouble(), rnd.Next(0, 19), "Jon Favreau"));
            pelis.Add(new Pelicula("Los Cazafantasmas", rnd.Next(60, 180) + rnd.NextDouble(), rnd.Next(0, 19), "Jason Reitman"));
            pelis.Add(new Pelicula("Terminator", rnd.Next(60, 180) + rnd.NextDouble(), rnd.Next(0, 19), "James Cameron"));
            pelis.Add(new Pelicula("Fight club", rnd.Next(60, 180) + rnd.NextDouble(), rnd.Next(0, 19), "David Fincher"));
            pelis.Add(new Pelicula("El resplandor", rnd.Next(60, 180) + rnd.NextDouble(), rnd.Next(0, 19), "Stanley Kubrick"));

            for (int i = 8; i > 0; i--) {                                       //
                for (int j = 0; j < 9; j++) {                                   //
                    asientos.Add(new Asiento(i, (char)(65 + j)));               // Generación de asientos
                }                                                               //
            }                                                                   //

            Sala sala = new Sala(pelis[rnd.Next(0, pelis.Count())], rnd.Next(0, 75) + Math.Round(rnd.NextDouble(), 2), asientos);

            for (int i = 0; i < 144; i++)
            {
                espectadores.Add(new Espectador(nombres[rnd.Next(0, nombres.Length)], rnd.Next(5, 60), rnd.Next(0, 100) + Math.Round(rnd.NextDouble(), 2)));
            }

            for (int i = 0; i < espectadores.Count(); i++) {
                crearPantalla(asientos);
                disponibles = asientos.Count(p => p.ocupado == false);

                if (disponibles != 0)
                {
                    Console.SetCursorPosition(50, 10);
                    if (sala.puedeSentarse(espectadores[i], rnd))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(espectadores[i].Mostrar());
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(espectadores[i].Mostrar());
                        Console.ResetColor();
                    }

                    Thread.Sleep(125);
                    Console.Clear();
                }
                else {
                    break;
                } 
            }

            crearPantalla(asientos);

            Console.SetCursorPosition(50, 10);

            if (asientos.Count(p => p.ocupado == false) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Todos los asientos se han vendido!");
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Se ha terminado la fila.");
            }

            Console.ReadKey();
        }
    }
}