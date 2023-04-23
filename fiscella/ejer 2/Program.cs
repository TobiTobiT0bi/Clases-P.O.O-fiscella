using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 2. Crear un programa que simule un cajero automático, permitiendo al usuario hacer depósitos, retiros y consultar su saldo.

namespace ejer_2
{
    public class Usuario {

        int saldo;
        string nombre;

        public int Saldo 
        {
            get {
                return saldo;
            }  
            set
            {
                saldo = value;
            }
        }

        public string Info
        {
            get
            {
                return nombre + ", " + saldo + "$";
            }
        }

        public Usuario() { }

        public Usuario(int saldo)
        {
            this.saldo = saldo;
        }
    }
    internal class Program
    {
        static void CrearMenu(string[] menu) {
            for (int i = 0; i < menu.Length; i++) {
                if (i == 0)
                {
                    Console.SetCursorPosition(30, 8);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }
                else {
                    Console.SetCursorPosition(30, (i + 8));
                    Console.WriteLine(menu[i]);
                }               
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Usuario usu = new Usuario(15000);

            string[] menuPrincipal = {
                " 1. depositos  ",
                " 2. retiros    ",
                " 3. saldo      ",
            };
            int pos = 0;

            CrearMenu(menuPrincipal);

            while (true) {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow && pos < 2)
                {
                    Console.SetCursorPosition(30, (pos + 8));
                    Console.WriteLine(menuPrincipal[pos]);
                    pos++;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(30, (pos + 8));
                    Console.WriteLine(menuPrincipal[pos]);
                    Console.ResetColor();
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
                    if(pos == 0){
                        Console.Clear();
                        Console.SetCursorPosition(30, 8);
                        Console.WriteLine("saldo del usuario: " + usu.Saldo);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(30, Console.CursorTop);
                        Console.Write("Ingrese monto a depositar:"); 
                        Console.ResetColor();
                        Console.Write(" ");
                        int monto = Convert.ToInt16(Console.ReadLine());
                        usu.Saldo += monto;

                        Console.Clear();
                        pos = 0;
                        CrearMenu(menuPrincipal);
                    }

                    if (pos == 1)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(30, 8);
                        Console.WriteLine("saldo del usuario: " + usu.Saldo);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(30, Console.CursorTop);
                        Console.Write("Ingrese monto a retirar:");
                        Console.ResetColor();
                        Console.Write(" ");
                        int monto = Convert.ToInt16(Console.ReadLine());
                        usu.Saldo -= monto;

                        Console.Clear();
                        pos = 0;
                        CrearMenu(menuPrincipal);
                    }

                    if (pos == 2)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(30, 8);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine("saldo del usuario: " + usu.Saldo);
                        Console.ReadKey();
                        Console.ResetColor();

                        Console.Clear();
                        pos = 0;
                        CrearMenu(menuPrincipal);
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
