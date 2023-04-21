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

    public class configuracion {
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
        public string email;

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

        public string mostrar() { 
            return this.NombreCompleto + ", " + edad + ", " + email;
        }
    }

    internal class Program
    {

        static void generar(Random rand1, Random rand2, List<Persona> personas, string[] nombres, string[] apellidos) {
            string nombre = nombres[rand1.Next(0, nombres.Length)];
            string ape = apellidos[rand2.Next(0, apellidos.Length)];
            string email = nombre + ape + "@hotmail.com";

            personas.Add(new Persona(nombre, ape, rand1.Next(0, 60), email));
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            List<Persona> personas = new List<Persona>();
            configuracion config = new configuracion();
            Random rand = new Random();
            Random randape = new Random();
            compara comparador = new compara();
            bool color = false;

            bool nace = false;
            bool muere = false;
            bool refresh = false;

            DateTime hora = DateTime.Now;
            DateTime horaActual;

            DateTime DesdeNuevo = DateTime.Now;
            DateTime DesdeMuerte = DateTime.Now;
            DateTime DesdeRefresh = DateTime.Now;
            
            string[] nombres = {"abbott", "acosta", "adams", "adkins", "aguilar", "abby", "abigail", "adele", "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian", "John", "Paul", "Ringo", "George"};
            string[] apellidos = { "Lennon", "McCartney", "Starr", "Harrison", "Vader", "Training", "Coman", "Kappou", "Oviedo", "abraham"};

            for (int i = 0; i < 10; i++) {

                generar(rand, randape, personas, nombres, apellidos);
                
            }
            foreach (Persona p in personas)
            {
                Console.WriteLine(p.mostrar());
            }

            while (true) {
                horaActual = DateTime.Now;
                TimeSpan timeSpan = horaActual - hora;

                TimeSpan nuevo = horaActual - DesdeNuevo;
                TimeSpan muerto = horaActual - DesdeMuerte;
                TimeSpan recarga = horaActual - DesdeRefresh;

                if (timeSpan.Seconds % config.Nacimiento == 0 && nace == false) {
                    generar(rand, randape, personas, nombres, apellidos);
                    nace = true;
                    color = true;
                    DesdeNuevo = DateTime.Now;
                }
                if (nuevo.Seconds == 1) { 
                    nace = false;
                }


                if (timeSpan.Seconds % config.Muerte == 0 && muere == false)
                {
                    personas.RemoveAt(rand.Next(0, personas.Count));
                    muere = true;
                    DesdeMuerte = DateTime.Now;
                }
                if(muerto.Seconds == 1)
                {
                    muere= false;
                }

                if (timeSpan.Seconds % config.Mostrar == 0 && refresh == false)
                {
                    Console.Clear();
                    if (color == true)
                    {
                        for (int i = 0; i < personas.Count; i++)
                        {
                            if (i == personas.Count)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine(personas[i].mostrar());
                                Console.ResetColor();
                            }
                            Console.WriteLine(personas[i].mostrar());
                        }
                        color = false;
                    }
                    else {
                        foreach (Persona p in personas)
                        {
                            Console.WriteLine(p.mostrar());
                        }
                    }

                    Console.WriteLine("\n cantidad de habitantes de argentina: " + personas.Count);
                    refresh = true;
                    DesdeRefresh = DateTime.Now;
                }
                if (recarga.Seconds == 1) { 
                    refresh = false;
                }

                personas.Sort(comparador);
            }
        }
    }
}
