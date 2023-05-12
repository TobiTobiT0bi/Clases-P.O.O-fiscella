using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
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
Métodos de todos los atributos, excepto de entregado.
Métodos set de todos los atributos, excepto de entregado.
Crearemos una clase Videojuego con las siguientes características:
Sus atributos son titulo, horas estimadas, entregado, genero y compañia.
Por defecto, las horas estimadas serán de 10 horas y entregado false. El resto de atributos serán valores por defecto según el tipo del atributo.
Los constructores que se implementarán serán:
Un constructor por defecto.
Un constructor con el título y horas estimadas. El resto por defecto.
Un constructor con todos los atributos, excepto de entregado.
Los métodos que se implementara serán:
Métodos get de todos los atributos, excepto de entregado.
Métodos set de todos los atributos, excepto de entregado.
Como vemos, en principio, las clases anteriores no son padre-hija, pero si tienen en común, por eso vamos a hacer una interfaz llamada Entregable con los siguientes métodos:
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
    class Serie
    {
        const int tempoDefecto = 3;
        const bool entregaDefecto = false;

        public string titulo;
        public int temporadas = tempoDefecto;
        public bool entregado = entregaDefecto;
        public string genero;
        public string creador;

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

        static public Serie agregarSerie(string titulo, string creador)
        {
            return new Serie(titulo, creador);
        }
        static public Serie agregarSerie(string titulo, int temporadas, string genero, string creador)
        {
            return new Serie(titulo, temporadas, genero, creador);
        }
    }

    class Videojuego
    {
        public string titulo;
        public int horasEstimadas = 10;
        public bool entregado = false;
        public string genero;
        public string compañia;

        public Videojuego()
        {

        }
        public Videojuego(string titulo, int horasEstimadas)
        {
            this.titulo = titulo;
            this.horasEstimadas = horasEstimadas;
        }
        public Videojuego(string titulo, int horasEstimadas, string genero, string compañia)
        {
            this.titulo = titulo;
            this.horasEstimadas = horasEstimadas;
            this.genero = genero;
            this.compañia = compañia;
        }

        static public Videojuego agregarJuego(string titulo, int horasEstimadas)
        {
            return new Videojuego(titulo, horasEstimadas);
        }
        static public Videojuego agregarJuego(string titulo, int horasEstimadas, string genero, string compañia)
        {
            return new Videojuego(titulo, horasEstimadas, genero, compañia);
        }
    }

    class Entregable
    {
        static public void entregar(Videojuego juego)
        {
            juego.entregado = true;
        }
        static public void entregar(Serie serie)
        {
            serie.entregado = true;
        }
        static public void devolver(Videojuego juego)
        {
            juego.entregado = false;
        }
        static public void devolver(Serie serie)
        {
            serie.entregado = false;
        }
        static public bool isEntregado(Videojuego juego)
        {
            return juego.entregado;
        }
        static public bool isEntregado(Serie serie)
        {
            return serie.entregado;
        }
        static public int compareTo(Videojuego[] juegos)
        {
            int mayorJuego = 0;
            int mayorJ = juegos[0].horasEstimadas;

            for (int i = 0; i < 5; i++)
            {
                int j = juegos[i].horasEstimadas;
                if (mayorJ < j)
                {
                    mayorJuego = i;
                    mayorJ = juegos[i].horasEstimadas;
                }
            }
            return mayorJuego;
        }
        static public int compareTo(Serie[] series)
        {
            int mayorSerie = 0;
            int mayorS = series[0].temporadas;

            for (int i = 0; i < 5; i++)
            {
                if (mayorS < series[i].temporadas)
                {
                    mayorSerie = i;
                    mayorS = series[i].temporadas;
                }
            }
            return mayorSerie;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Serie[] series = new Serie[5];
            Videojuego[] juegos = new Videojuego[5];

            series[0] = Serie.agregarSerie("HIMYM", 9, "Comedia", "Craig Thomas");
            series[1] = Serie.agregarSerie("Los chicos del barrio", 6, "Comedia", "Carter Bays");
            series[2] = Serie.agregarSerie("Friends", 10, "Comedia", "James Burrows");
            series[3] = Serie.agregarSerie("Brooklyn Nine-Nine", 8, "Comedia", "Michael Schur");
            series[4] = Serie.agregarSerie("The Office", 9, "Comedia", "Greg Daniels");
            juegos[0] = Videojuego.agregarJuego("Hollow Knight", 50, "Metroidvania", "TeamCherry");
            juegos[1] = Videojuego.agregarJuego("Hollow Knight: Silksong", 100, "Metroidvania", "TeamCherry");
            juegos[2] = Videojuego.agregarJuego("The Legend of Zelda: Breath Of The Wild", 50, "Mundo Abierto", "Nintendo");
            juegos[3] = Videojuego.agregarJuego("The Stanley Parable", 1000, "Puzzles", "Valve");
            juegos[4] = Videojuego.agregarJuego("Elden Ring", 200, "Mundo Abierto", "From SoftWare");

            Entregable.entregar(juegos[2]);
            Entregable.entregar(juegos[1]);
            Entregable.entregar(juegos[3]);
            Entregable.entregar(series[2]);
            Entregable.entregar(series[0]);

            List<int> seriesEntregadas = new List<int>();
            List<int> juegosEntregados = new List<int>();


            for (int i = 0; i < 5; i++)
            {
                if (Entregable.isEntregado(series[i]))
                {
                    seriesEntregadas.Add(i);
                }
                if (Entregable.isEntregado(juegos[i]))
                {
                    juegosEntregados.Add(i);
                }
            }
            Console.WriteLine("Cantidad de juegos entregados: " + juegosEntregados.Count);
            Console.WriteLine("Estos juegos son: ");
            foreach (int ju in juegosEntregados)
            {
                Console.WriteLine(juegos[ju].titulo);
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Cantidad de series entregadas: " + seriesEntregadas.Count);
            Console.WriteLine("Estas series son: ");
            foreach (int se in seriesEntregadas)
            {
                Console.WriteLine(series[se].titulo);
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("El juego con mas horas estimadas es: " + juegos[Entregable.compareTo(juegos)].titulo);
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("La serie con mas temporadas es: " + series[Entregable.compareTo(series)].titulo);

            Console.ReadKey();
        }
    }
}
