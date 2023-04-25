using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ej11
{
    class comparapais : IComparer<Persona>
    {
        public int Compare(Persona x, Persona y)
        {
            string nombx = x.Nacion;
            string nomby = y.Nacion;

            if (nombx == "" || nomby == "")
            {
                return 0;
            }

            return nombx.CompareTo(nomby);
        }
    }

    class compara : IComparer<Persona>
    {
        public int Compare(Persona x, Persona y)
        {
            string nombx = x.Apellido;
            string nomby = y.Apellido;

            if (nombx == "" || nomby == "")
            {
                return 0;
            }

            return nombx.CompareTo(nomby);

        }
    }

    public class configuracion
    {
        int nacimiento = 30;    //segundos
        int muerte = 60;        // segundos
        int show = 10;          // segundos
        int masivo = 2;         // minutos

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

        public int Exterminio
        {
            get
            {
                return masivo;
            }
        }
    }
    class Persona
    {
        string nombre;
        string apellido;
        int edad;
        string email;
        string nacionalidad;


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

        public string Nacion
        {
            get
            {
                return nacionalidad;
            }
        }

        public Persona(string nombre, string apellido, int edad, string email, string nacio)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.email = email;
            this.nacionalidad = nacio;
        }

        public string mostrar()
        {
            return this.NombreCompleto + ", " + edad + ", " + email + ", " + nacionalidad;
        }
    }

    internal class Program
    {

        static string generar(Random rand1, Random rand2, List<Persona> personas, string[] nombres, string[] apellidos, string[] nacionalidad)
        {
            string nombre = nombres[rand1.Next(0, nombres.Length)];
            string ape = apellidos[rand2.Next(0, apellidos.Length)];
            string nacio = nacionalidad[rand1.Next(0, nacionalidad.Length)];
            string email = nombre + ape + "@hotmail.com";

            personas.Add(new Persona(nombre, ape, rand1.Next(0, 60), email, nacio));
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
            comparapais comparadorpais = new comparapais();
            int cargasMinutos = 0;

            string msg = "";
            string nuevo = "";
            bool showmsg = false;

            bool color = false;
            bool inicio = false;

            bool nace = true;
            bool muere = true;
            bool refresh = false;
            bool reinicio = true;

            DateTime hora = DateTime.Now;
            DateTime horaActual;

            DateTime DesdeNaci = DateTime.Now;
            DateTime DesdeMuerte = DateTime.Now;
            DateTime DesdeRefresh = DateTime.Now;
            DateTime DesdeExti = DateTime.Now;

            string[] nombres = { "Abbott", "Acosta", "Adams", "Adkins", "Aguilar", "Abby", "Abigail", "Adele", "Aaron", "Abdul", "Abe", "Abel", "Abraham", "Adam", "Adan", "Adolfo", "Adolph", "Adrian", "John", "Paul", "Ringo", "George" };
            string[] apellidos = { "Lennon", "McCartney", "Starr", "Harrison", "Vader", "Training", "Coman", "Kappou", "Oviedo", "Abraham" };
            string[] nacionalidad = { "Argentina", "Paraguay", "Brasil" };

            for (int i = 0; i < 10; i++)
            {

                generar(rand, randape, personas, nombres, apellidos, nacionalidad);

            }
            foreach (Persona p in personas)
            {
                Console.WriteLine(p.mostrar());
            }

            while (true)
            {
                int arg = 0;
                int para = 0;
                int br = 0;

                horaActual = DateTime.Now;
                TimeSpan timeSpan = horaActual - hora;

                TimeSpan nacimiento = horaActual - DesdeNaci;
                TimeSpan muerto = horaActual - DesdeMuerte;
                TimeSpan recarga = horaActual - DesdeRefresh;
                TimeSpan exti = horaActual - DesdeExti;

                if (timeSpan.Seconds % config.Nacimiento == 0 && nace == false)
                {
                    nuevo = generar(rand, randape, personas, nombres, apellidos, nacionalidad);
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
                    cargasMinutos++;
                }
                if (muerto.Seconds == 1)
                {
                    muere = false;
                }

                if (timeSpan.Seconds % config.Mostrar == 0 && refresh == false)
                {
                    Console.Clear();
                    personas.Sort(comparadorpais);

                    foreach (Persona p in personas)
                    {
                        if (p.Nacion == "Argentina")
                        {
                            arg++;
                        }
                        if (p.Nacion == "Paraguay")
                        {
                            para++;
                        }
                        if (p.Nacion == "Brasil")
                        {
                            br++;
                        }
                    }

                    if (color == true)
                    {
                        for (int i = 0; i < personas.Count; i++)
                        {
                            if (i == arg || i == (arg + br))
                            {
                                Console.WriteLine("");
                            }
                            if (i == personas.FindIndex(p => p.NombreCompleto == nuevo) && inicio == true)
                            {
                                Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine(personas[i].mostrar());
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine(personas[i].mostrar());
                            }
                        }
                        color = false;
                        inicio = true;
                    }
                    else
                    {
                        int index = 0;
                        foreach (Persona p in personas)
                        {
                            if (index == arg || index == (arg + br))
                            {
                                Console.WriteLine("");
                            }
                            Console.WriteLine(p.mostrar());
                            index++;
                        }
                        inicio = true;
                    }

                    Console.WriteLine("\nCantidad de habitantes de Argentina: " + arg);
                    Console.WriteLine("\nCantidad de habitantes de Brasil: " + br);
                    Console.WriteLine("\nCantidad de habitantes de Paraguay: " + para);

                    if (showmsg == true)
                    {
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

                if (cargasMinutos == config.Exterminio && reinicio == false)
                {
                    int mueren = rand.Next(0, 3);
                    if (mueren == 0) {
                        personas.RemoveRange(0, arg);
                    }
                    if (mueren == 1) {
                        personas.RemoveRange(arg, br);
                    }
                    if (mueren == 2) {
                        personas.RemoveRange(arg + br, para);
                    }       
                    DesdeExti = DateTime.Now;
                    cargasMinutos = 0;
                    reinicio = true;
                }
                if (exti.Seconds == 1)
                {
                    reinicio = false;
                }

                //Console.SetCursorPosition(0, 25); Console.Write(timeSpan.Seconds);
                //Console.SetCursorPosition(0, 26); Console.Write(cargasMinutos);

            }
        }
    }
}
