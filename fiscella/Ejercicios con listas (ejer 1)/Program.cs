using System;
using System.Collections.Generic;

namespace Ej11
{
    class compara : IComparer<Persona>
    {
        public int Compare(Persona x, Persona y)
        {
            string nombx = x.Nombre;
            string nomby = y.Nombre;

            if (nombx == "" || nomby == "")
            {
                return 0;
            }

            return nombx.CompareTo(nomby);

        }
    }

    public class configuracion
    {
        int nacimiento = 30;
        int muerte = 60;
        int show = 10;

        public int Nacimiento
        {
            get
            {
                return nacimiento;
            }
        }

        public int Muerte
        {
            get
            {
                return muerte;
            }
        }
        public int Mostrar
        {
            get
            {
                return show;
            }
        }
    }
    class Persona
    {
        string nombre;
        string apellido;
        int edad;
        string email;


        public string NombreCompleto
        {
            get
            {
                return nombre + ' ' + apellido;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
        }

        public Persona(string nombre, string apellido, int edad, string email)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.email = email;
        }

        public string mostrar()
        {
            return this.NombreCompleto + ", " + edad + ", " + email;
        }
    }

    internal class Program
    {

        static string generar(Random rand1, Random rand2, List<Persona> personas, string[] nombres, string[] apellidos)
        {
            string nombre = nombres[rand1.Next(0, nombres.Length)];
            string ape = apellidos[rand2.Next(0, apellidos.Length)];
            string email = nombre + ape + "@hotmail.com";

            personas.Add(new Persona(nombre, ape, rand1.Next(0, 60), email));
            Persona index = personas.Find(p => p.NombreCompleto == (nombre + ' ' + ape));
            return index.NombreCompleto;
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            List<Persona> personas = new List<Persona>();
            configuracion config = new configuracion();
            Random rand = new Random();
            Random randape = new Random();
            compara comparador = new compara();
            string msg = "";
            string nuevo = "";
            bool showmsg = false;

            bool color = false;
            bool inicio = false;

            bool nace = true;
            bool muere = true;
            bool refresh = false;

            DateTime hora = DateTime.Now;
            DateTime horaActual;

            DateTime DesdeNaci = DateTime.Now;
            DateTime DesdeMuerte = DateTime.Now;
            DateTime DesdeRefresh = DateTime.Now;

            string[] nombres = { "abbott", "acosta", "adams", "adkins", "aguilar", "abby", "abigail", "adele", "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian", "John", "Paul", "Ringo", "George" };
            string[] apellidos = { "Lennon", "McCartney", "Starr", "Harrison", "Vader", "Training", "Coman", "Kappou", "Oviedo", "abraham" };

            for (int i = 0; i < 10; i++)
            {

                generar(rand, randape, personas, nombres, apellidos);

            }
            foreach (Persona p in personas)
            {
                Console.WriteLine(p.mostrar());
            }

            while (true)
            {
                horaActual = DateTime.Now;
                TimeSpan timeSpan = horaActual - hora;

                TimeSpan nacimiento = horaActual - DesdeNaci;
                TimeSpan muerto = horaActual - DesdeMuerte;
                TimeSpan recarga = horaActual - DesdeRefresh;

                if (timeSpan.Seconds % config.Nacimiento == 0 && nace == false)
                {
                    nuevo = generar(rand, randape, personas, nombres, apellidos);
                    nace = true;
                    color = true;
                    DesdeNaci = DateTime.Now;
                }
                if (nacimiento.Seconds == 1)
                {
                    nace = false;
                }


                if (timeSpan.Seconds % config.Muerte == 0 && muere == false)
                {
                    int randi = rand.Next(0, personas.Count);
                    msg = "\n usuario eliminado: " + personas[randi].mostrar();
                    showmsg = true;
                    personas.RemoveAt(randi);
                    muere = true;
                    DesdeMuerte = DateTime.Now;
                }
                if (muerto.Seconds == 1)
                {
                    muere = false;
                }

                if (timeSpan.Seconds % config.Mostrar == 0 && refresh == false)
                {
                    Console.Clear();
                    personas.Sort(comparador);
                    if (color == true)
                    {
                        for (int i = 0; i < personas.Count; i++)
                        {
                            if (i == personas.FindIndex(p => p.NombreCompleto == nuevo) && inicio == true)
                            {
                                Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine(personas[i].mostrar());
                                Console.ResetColor();
                            }
                            else {
                                Console.WriteLine(personas[i].mostrar());
                            }                           
                        }
                        color = false;
                        inicio = true;
                    }
                    else
                    {
                        foreach (Persona p in personas)
                        {
                            Console.WriteLine(p.mostrar());
                        }
                        inicio = true;
                    }

                    Console.WriteLine("\n cantidad de habitantes de argentina: " + personas.Count);

                    if (showmsg == true) {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(msg);
                        Console.ResetColor();
                        showmsg = false;
                    }                

                    refresh = true;
                    DesdeRefresh = DateTime.Now;
                }
                if (recarga.Seconds == 1)
                {
                    refresh = false;
                }
            }
        }
    }
}
