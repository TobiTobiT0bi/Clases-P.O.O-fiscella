using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 8. Crear un programa que simule una biblioteca, permitiendo al usuario buscar y prestar libros, y llevando un registro de los préstamos y devoluciones.

namespace ejer_8
{
    public class operacion
    {
        string nombre_libro;
        string fecha_inicio;
        string tipo;
        bool tuyo;

        public string Info
        {
            get
            {
                return nombre_libro + ", Fecha: " + fecha_inicio + ", tipo: " + tipo;
            }
        }

        public string InfoDevo
        {
            get
            {
                return nombre_libro + ", Fecha: " + fecha_inicio;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre_libro;
            }
        }

        public bool Tuyo
        {
            get
            {
                return tuyo;
            }

            set { 
                this.tuyo = value;
            }
        }

        public operacion() { }

        public operacion(string nombre, string fecha_inicio, string tipo, bool tuyo)
        {
            this.nombre_libro = nombre;
            this.fecha_inicio = fecha_inicio;
            this.tipo = tipo;
            this.tuyo = tuyo;
        }
    }

    public class libro
    {
        string nombre;
        public string estado;

        public string Info
        {
            get
            {
                return nombre + ", Estado: " + estado;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
        }

        public libro() { }

        public libro(string nombre, string estado)
        {
            this.nombre = nombre;
            this.estado = estado;
        }
    }

    internal class Program
    {
        static void CrearMenu(string[] menu, bool prestamo)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(30, 8);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }
                else if(i != 3)
                {
                    Console.SetCursorPosition(30, (i + 8));
                    Console.WriteLine(menu[i]);
                }
                else if (prestamo == true)
                {
                    Console.SetCursorPosition(30, (i + 8));
                    Console.WriteLine(menu[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            List<libro> libros = new List<libro>();
            List<operacion> operaciones = new List<operacion>();
            bool prestamoActivo = false;

            libros.Add(new libro("elpepe", "en stock"));
            libros.Add(new libro("farenheit", "prestado"));
            libros.Add(new libro("con la sangre al ojo", "en stock"));
            libros.Add(new libro("el paciente cero", "en stock"));
            libros.Add(new libro("la voz perdida", "prestado"));
            libros.Add(new libro("Don quijote de la mancha", "en stock"));

            Console.CursorVisible = false;

            string[] menuPrincipal = {
                " 1. buscar libros                 ",
                " 2. prestar libros                ",
                " 3. prestamos y devoluciones      ",
                " 4. devolver un libro            !"
            };
            int pos = 0;

            CrearMenu(menuPrincipal, prestamoActivo);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.DownArrow && pos < 3)
                {
                    if (pos != 2) {
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menuPrincipal[pos]);
                        pos++;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menuPrincipal[pos]);
                        Console.ResetColor();
                    }
                    else if (prestamoActivo == true) {
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menuPrincipal[pos]);
                        pos++;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menuPrincipal[pos]);
                        Console.ResetColor();
                    }
                }
                    

                if (key.Key == ConsoleKey.UpArrow && pos > 0)
                {
                    Console.SetCursorPosition(30, (pos + 8));
                    Console.WriteLine(menuPrincipal[pos]);
                    pos--;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(30, (pos + 8));
                    Console.WriteLine(menuPrincipal[pos]);
                    Console.ResetColor();
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    if (pos == 0)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(30, 8);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("nombre del libro: ");
                        Console.ResetColor();
                        Console.Write(" ");
                        string nombre = Console.ReadLine();

                        libro librete = libros.Find(l => l.Nombre == nombre);

                        Console.Clear();
                        Console.SetCursorPosition(30, 8);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(librete.Info);

                        Console.ReadKey();
                        pos = 0;
                        CrearMenu(menuPrincipal, prestamoActivo);
                    }

                    if (pos == 1)
                    {
                        int salir = -1;

                        Console.Clear();
                        for (int i = 0; i < libros.Count; i++)
                        {
                            Console.SetCursorPosition(30, 8 + i);
                            Console.WriteLine((i + 1) + ". " + libros[i].Info);
                            if (i == libros.Count - 1) {
                                Console.SetCursorPosition(30, 9 + i);
                                Console.WriteLine((i + 2) + ". salir");
                                salir = i + 2;
                            }
                        }
                        int presta = Convert.ToInt16(Convert.ToString(Console.ReadKey(true).KeyChar));

                        if (presta == salir)
                        {
                            Console.Clear();
                            pos = 0;
                            CrearMenu(menuPrincipal, prestamoActivo);
                        }
                        else if (libros[presta - 1].estado == "prestado")
                        {
                            Console.SetCursorPosition(30, Console.CursorTop);
                            Console.WriteLine("Imposible prestar, no hay stock");
                        }
                        else {
                            libros[presta - 1].estado = "Prestado";
                            operaciones.Add(new operacion(libros[presta - 1].Nombre, Convert.ToString(DateTime.Now), "prestamo", true));
                            prestamoActivo = true;

                            Console.Clear();
                            pos = 0;
                            CrearMenu(menuPrincipal, prestamoActivo);
                        }                       
                    }

                    if (pos == 2)
                    {
                        Console.Clear();

                        for (int i = 0; i < operaciones.Count; i++) {
                            Console.SetCursorPosition(30, 8 + i);
                            Console.WriteLine(operaciones[i].Info);
                        }
                        Console.ReadKey();

                        Console.Clear();
                        pos = 0;
                        CrearMenu(menuPrincipal, prestamoActivo);
                    }

                    if (pos == 3)
                    {
                        Console.Clear();

                        for (int i = 0; i < operaciones.Count; i++)
                        {
                            if (operaciones[i].Tuyo == true) {
                                Console.SetCursorPosition(30, 8 + i);
                                Console.WriteLine((i + 1) + ". " + operaciones[i].InfoDevo);
                            }                        
                        }
                        int presta = Convert.ToInt16(Convert.ToString(Console.ReadKey(true).KeyChar));

                        libros.Find(l => l.Nombre == operaciones[presta - 1].Nombre).estado = "En stock";
                        operaciones[presta - 1].Tuyo = false;
                        operaciones.Add(new operacion(libros[presta - 1].Nombre, Convert.ToString(DateTime.Now), "Devolucion", false));

                        
                        operacion compruebo = operaciones.Find(o => o.Tuyo == true);
                        if (compruebo == null) {
                            prestamoActivo = false;
                        }
                        
                        Console.Clear();
                        pos = 0;
                        CrearMenu(menuPrincipal, prestamoActivo);
                    }
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
