using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//6. Crear un programa que permita al usuario ingresar una lista de tareas y organizarlas por orden de prioridad.

namespace ejer_6
{
    public class compara: IComparer<tarea> { 
        public int Compare(tarea tare1, tarea tare2)
        {
            int x = tare1.priori;
            int y = tare2.priori;
            if (x > y) {
                return 1;
            }
            if (x < y)
            {
                return -1;
            }
            else {
                return 0;
            }
        }
    }

    public class tarea {
        int prioridad;
        string prioritext;
        string nombre;

        public tarea() { }

        public tarea(int prioridad, string prioritext, string nombre) {
            this.prioridad = prioridad;
            this.prioritext = prioritext;
            this.nombre = nombre;
        }

        public string Info 
        {
            get
            {
                return nombre + ", " + prioridad + ". " + prioritext; 
            }
        }

        public int priori
        {
            get
            {
                return prioridad;
            }
        }

    }
    internal class Program
    {
        static void Menu(string[] menu) {
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
                else
                {
                    Console.SetCursorPosition(30, (i + 8));
                    Console.WriteLine(menu[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            List<tarea> tareas = new List<tarea>();
            compara comparador = new compara();

            tareas.Add(new tarea(1, "muy importante", "pasear perro"));
            tareas.Add(new tarea(2, "importante", "pelar papas"));
            tareas.Add(new tarea(1, "muy importante", "comer"));
            tareas.Add(new tarea(3, "prescindible", "ir a correr"));
            tareas.Add(new tarea(4, "sin importancia", "jugar"));
            tareas.Add(new tarea(2, "importante", "trabajar"));

            string[] menu = {
            " 1. agregar tarea                ",
            " 2. listar tareas por prioridad  "
            };
            int pos = 0;

            Menu(menu);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow && pos < 2)
                {
                    Console.SetCursorPosition(30, (pos + 8));
                    Console.WriteLine(menu[pos]);
                    pos++;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(30, (pos + 8));
                    Console.WriteLine(menu[pos]);
                    Console.ResetColor();
                }

                if (key.Key == ConsoleKey.UpArrow && pos > 0)
                {
                    Console.SetCursorPosition(30, (pos + 8));
                    Console.WriteLine(menu[pos]);
                    pos--;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(30, (pos + 8));
                    Console.WriteLine(menu[pos]);
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
                        Console.SetCursorPosition(30, Console.CursorTop);
                        Console.Write("Ingrese tarea:");
                        Console.ResetColor();
                        Console.Write(" ");
                        string tarea = Console.ReadLine();

                        Console.SetCursorPosition(30, Console.CursorTop);
                        Console.WriteLine("Seleccione prioridad: 1. muy importante");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("2. importante");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("3. prescindible");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("4. sin importancia");                        
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        int importancia = Convert.ToInt16(Convert.ToString(Console.ReadKey(true).KeyChar));
                        string impotext = "";

                        switch (importancia) {
                            case 1:
                                impotext = "muy importante";
                                break;
                            case 2:
                                impotext = "importante";
                                break;
                            case 3:
                                impotext = "prescindible";
                                break;
                            case 4:
                                impotext = "sin importancia";
                                break;
                        }

                        tareas.Add(new tarea(importancia, impotext, tarea));

                        Console.Clear();
                        Menu(menu);
                    }
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    if (pos == 1)
                    {
                        Console.Clear();
                        
                        tareas.Sort(comparador);
                        for (int i = 0; i < tareas.Count; i++) {
                            Console.SetCursorPosition(30, 8 + i);
                            Console.WriteLine(tareas[i].Info);
                        }

                        Console.ReadKey();

                        Console.Clear();
                        pos = 0;
                        Menu(menu);
                    }
                }
            }
        }
    }
}
