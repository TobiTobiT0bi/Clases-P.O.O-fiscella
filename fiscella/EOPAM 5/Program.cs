using ejerciciosObligatorios5;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

/*
5) Crearemos una clase llamada Serie con las siguientes características:
Sus atributos son título, número de temporadas, entregado, genero y creador.
Por defecto, el número de temporadas es de 3 temporadas y entregado false. El resto de atributos serán valores por defecto según el tipo del atributo.
Los constructores que se implementarán serán:
Un constructor por defecto.
Un constructor con título y creador. El resto por defecto.
Un constructor con todos los atributos, excepto de entregado.
Los métodos que se implementara serán:
Métodos get de todos los atributos, excepto de entregado.
Métodos set de todos los atributos, excepto de entregado.
Crearemos una clase Videojuego con las siguientes características:
Sus atributos son titulo, horas estimadas, entregado, genero y compañia.
Por defecto, las horas estimadas serán de 10 horas y entregado false. El resto de atributos serán valores por defecto según el tipo del atributo.
Los constructores que se implementarán serán:
Un constructor por defecto.
Un constructor con el título y horas estimadas. El resto por defecto. panqueques
Un constructor con todos los atributos, excepto de entregado.
Los métodos que se implementara serán:
Métodos get de todos los atributos, excepto de entregado.
Métodos set de todos los atributos, excepto de entregado.
Como vemos, en principio, las clases anteriores no son padre-hija, pero si tienen cosas en común, por eso vamos a hacer una interfaz llamada Entregable con los siguientes métodos:
entregar(): cambia el atributo prestado a true.
devolver(): cambia el atributo prestado a false.
isEntregado(): devuelve el estado del atributo prestado.
Método compareTo (Object a), compara las horas estimadas en los videojuegos y en las series el número de temporadas. Como parámetro que tenga un objeto, no es necesario que implementen la interfaz Comparable. Recuerda el uso de los casting de objetos.
Implementa los anteriores métodos en las clases Videojuego y Serie. Ahora crea una aplicación ejecutable y realiza lo siguiente:
Crea dos arrays, uno de Series y otro de Videojuegos, de 5 posiciones cada uno.
Crea un objeto en cada posición del array, con los valores que desees, puedes usar distintos constructores.
Entrega algunos Videojuegos y Series con el método entregar().
Cuenta cuantos Series y Videojuegos hay entregados. Al contarlos, devuelvelos.
Por último, indica que el Videojuego tiene más horas estimadas y la serie con mas temporadas. Muestran en pantalla con toda su información

 */

namespace ejerciciosObligatorios5
{
    public class Serie
    {
        private const int tempoDefecto = 3;
        private const bool entregaDefecto = false;

        private string titulo;
        private int temporadas = tempoDefecto;
        public bool entregado = entregaDefecto;
        private string genero;
        private string creador;

        public Serie()
        {

        }

        public Serie(string titulo, string creador)
        {
            this.titulo = titulo;
            this.creador = creador;
        }
        public Serie(string titulo, int temporadas, string genero, string creador)
        {
            this.titulo = titulo;
            this.temporadas = temporadas;
            this.genero = genero;
            this.creador = creador;
        }

        public string Titulo {
            get { return titulo; } set { titulo = value; }
        }

        public int Temporadas
        {
            get { return temporadas; } set { temporadas = value; }
        }

        public string Genero {
            get { return genero; } set { genero = value; }
        }

        public string Creador { 
            get {  return creador; } set {  creador = value; }
        }
    }

    public class Videojuego
    {
        private const int horasDefecto = 10;
        private const bool entregaDefecto = false;

        private string titulo;
        private int horasEstimadas = horasDefecto;
        public bool entregado = entregaDefecto;
        private string genero;
        private string compania;

        public Videojuego()
        {

        }
        public Videojuego(string titulo, int horasEstimadas)
        {
            this.titulo = titulo;
            this.horasEstimadas = horasEstimadas;
        }
        public Videojuego(string titulo, int horasEstimadas, string genero, string compania)
        {
            this.titulo = titulo;
            this.horasEstimadas = horasEstimadas;
            this.genero = genero;
            this.compania = compania;
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public int Horas
        {
            get { return horasEstimadas; }
            set { horasEstimadas = value; }
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public string Compania
        {
            get { return compania; }
            set { compania = value; }
        }
    }

    class Entregable
    {
        static public void entregar(Videojuego game)
        {
            game.entregado = true;
        }
        static public void entregar(Serie serie)
        {
            serie.entregado = true;
        }
        static public void devolver(Videojuego game)
        {
            game.entregado = false;
        }
        static public void devolver(Serie serie)
        {
            serie.entregado = false;
        }
        static public bool isEntregado(Videojuego game)
        {
            return game.entregado;
        }
        static public bool isEntregado(Serie serie)
        {
            return serie.entregado;
        }
        static public Videojuego[] compareTo(Videojuego[] games)
        {
            Videojuego[] ordenado = new Videojuego[games.Length];

            ordenado = games.OrderBy(Videojuego => Videojuego.Horas).Reverse().ToArray();

            return ordenado;
        }
        static public Serie[] compareTo(Serie[] series)
        {
            Serie[] ordenado = new Serie[series.Length];

            ordenado = series.OrderBy(Serie => Serie.Temporadas).Reverse().ToArray();

            return ordenado;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Serie[] series = new Serie[5];
            Videojuego[] juegos = new Videojuego[5];
            Random rnd = new Random();

            series[0] = new Serie("How I Met Your Mother", 9, "Comedia", "Craig Thomas");
            series[1] = new Serie("Los chicos del barrio", 6, "Comedia", "Carter Bays");
            series[2] = new Serie("Los simpsons", 29, "Comedia", "James Burrows");
            series[3] = new Serie("Brooklyn Nine-Nine", 8, "Comedia", "Michael Schur");
            series[4] = new Serie("The Office", 9, "Comedia", "Greg Daniels");
            juegos[0] = new Videojuego("Hollow Knight", 50, "Metroidvania", "TeamCherry");
            juegos[1] = new Videojuego("Dark Souls 3", 1000, "Metroidvania", "TeamCherry");
            juegos[2] = new Videojuego("The Legend of Zelda: Tears Of The Kingdom", 250, "Mundo Abierto", "Nintendo");
            juegos[3] = new Videojuego("The Stanley Parable", 87600, "Puzzles", "Valve");
            juegos[4] = new Videojuego("Elden Ring", 500, "Mundo Abierto", "From SoftWare");

            for (int i = 0; i < 5; i++) {
                int clase = rnd.Next(1, 3);

                switch (clase)
                {

                    case 1:
                        Entregable.entregar(juegos[rnd.Next(0, 5)]);
                        break;
                    case 2:
                        Entregable.entregar(series[rnd.Next(0, 5)]);
                        break;
                }
            }   

            List<Serie> seriesEntregadas = new List<Serie>();
            List<Videojuego> juegosEntregados = new List<Videojuego>();


            for (int i = 0; i < 5; i++)
            {
                if (Entregable.isEntregado(series[i]))
                {
                    seriesEntregadas.Add(series[i]);
                }
                if (Entregable.isEntregado(juegos[i]))
                {
                    juegosEntregados.Add(juegos[i]);
                }
            }

            Console.WriteLine("Cantidad de juegos entregados: " + juegosEntregados.Count);
            Console.WriteLine("\nEstos juegos son: ");
            foreach(Videojuego ju in juegosEntregados)
            {
                Console.WriteLine(ju.Titulo);
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Cantidad de series entregadas: " + seriesEntregadas.Count);
            Console.WriteLine("\nEstas series son: ");
            foreach (Serie se in seriesEntregadas)
            {
                Console.WriteLine(se.Titulo);
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("El juego con mas horas estimadas es: " + Entregable.compareTo(juegos)[0].Titulo);
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("La serie con mas temporadas es: " + Entregable.compareTo(series)[0].Titulo);

            Console.ReadKey();
        }
    }
}
