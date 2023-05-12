using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_1
{
    internal class Program
    {
        public class Cuenta {
            private string titular;
            private double cantidad;

            public Cuenta(string titu)
            {
                this.titular = titu;
            }

            public Cuenta(string titu, double canti)
            { 
                this.titular = titu;
                this.cantidad = canti;
            }

            public void ingresar(double cantidad) {
                if (cantidad >= 0) { 
                    this.cantidad += cantidad;
                }
            }

            public void retirar(double cantidad) {
                if (this.cantidad - cantidad <= 0) {
                    this.cantidad = 0;
                }
                else { 
                    this.cantidad -= cantidad;
                }
            }


            public string Titular {
                get{
                    return titular;
                }
            }

            public double Cantidad
            {
                get{
                    return cantidad;
                }
            }
        }
        static void CrearMenu(string[] menu, int avance)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(30, 8 + avance);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(30, (i + 8) + avance);
                    Console.WriteLine(menu[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            string[] menuPrincipal = {
                " 1. ingresar   ",
                " 2. retirar    ",
                " 3. saldo      ",
            };
            int pos = 0;

            CrearMenu(menuPrincipal, 0);

            List<Cuenta> Cuentonas = new List<Cuenta>();

            Random rnd = new Random();
            double cantusu;

            for (int i = 0; i < 10; i++)
            {

                string nombreusuario;
                int cantemp = rnd.Next(350, 930);
                cantusu = cantemp + Math.Round(rnd.NextDouble(), 2);

                if (i < 3)
                {
                    nombreusuario = "fulanito fulanon n°" + (i + 1);
                }
                else if (i >= 3 && i < 6)
                {
                    nombreusuario = "foo fighters n°" + (i - 2);
                }
                else
                {
                    nombreusuario = "lets gooooo n°" + (i - 5);
                }

                Cuentonas.Add(new Cuenta(nombreusuario, cantusu));
            }

            while (true)
            {
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
                    if (pos == 0)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(30, 8);
                        Console.WriteLine("seleccione usuario: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Green;
                        for (int i = 0; i < Cuentonas.Count; i++)
                        {
                            if (i == 0)
                            {
                                Console.SetCursorPosition(30, 9);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine(Cuentonas[i].Titular);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.SetCursorPosition(30, (i + 9));
                                Console.WriteLine(Cuentonas[i].Titular);
                            }
                        }
                        int posCuentas = 0;

                        while (true)
                        {
                            ConsoleKeyInfo keyc = Console.ReadKey();

                            if (keyc.Key == ConsoleKey.DownArrow && posCuentas < Cuentonas.Count - 1)
                            {
                                Console.SetCursorPosition(30, (posCuentas + 9));
                                Console.WriteLine(Cuentonas[posCuentas].Titular);
                                posCuentas++;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(30, (posCuentas + 9));
                                Console.WriteLine(Cuentonas[posCuentas].Titular);
                                Console.ResetColor();
                            }

                            if (keyc.Key == ConsoleKey.UpArrow && posCuentas > 0)
                            {
                                Console.SetCursorPosition(30, (posCuentas + 9));
                                Console.WriteLine(Cuentonas[posCuentas].Titular);
                                posCuentas--;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(30, (posCuentas + 9));
                                Console.WriteLine(Cuentonas[posCuentas].Titular);
                                Console.ResetColor();
                            }

                            if (keyc.Key == ConsoleKey.Enter)
                            {

                                Console.Clear();
                                Console.SetCursorPosition(30, 8);
                                Console.WriteLine("saldo del usuario: " + Cuentonas[posCuentas].Cantidad);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(30, Console.CursorTop);
                                Console.Write("Ingrese monto a ingresar:");
                                Console.ResetColor();
                                Console.Write(" ");
                                double panqueques = Convert.ToDouble(Console.ReadLine());

                                Cuentonas[posCuentas].ingresar(panqueques);

                                Console.Clear();
                                CrearMenu(menuPrincipal, 0);
                                break;
                            }

                        }
                    }
                    if (pos == 1)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(30, 8);
                        Console.WriteLine("seleccione usuario: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Green;
                        for (int i = 0; i < Cuentonas.Count; i++)
                        {
                            if (i == 0)
                            {
                                Console.SetCursorPosition(30, 9);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine(Cuentonas[i].Titular);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.SetCursorPosition(30, (i + 9));
                                Console.WriteLine(Cuentonas[i].Titular);
                            }
                        }
                        int posCuentas = 0;

                        while (true)
                        {
                            ConsoleKeyInfo keyc = Console.ReadKey();

                            if (keyc.Key == ConsoleKey.DownArrow && posCuentas < Cuentonas.Count - 1)
                            {
                                Console.SetCursorPosition(30, (posCuentas + 9));
                                Console.WriteLine(Cuentonas[posCuentas].Titular);
                                posCuentas++;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(30, (posCuentas + 9));
                                Console.WriteLine(Cuentonas[posCuentas].Titular);
                                Console.ResetColor();
                            }

                            if (keyc.Key == ConsoleKey.UpArrow && posCuentas > 0)
                            {
                                Console.SetCursorPosition(30, (posCuentas + 9));
                                Console.WriteLine(Cuentonas[posCuentas].Titular);
                                posCuentas--;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(30, (posCuentas + 9));
                                Console.WriteLine(Cuentonas[posCuentas].Titular);
                                Console.ResetColor();
                            }

                            if (keyc.Key == ConsoleKey.Enter)
                            {

                                Console.Clear();
                                Console.SetCursorPosition(30, 8);
                                Console.WriteLine("saldo del usuario: " + Cuentonas[posCuentas].Cantidad);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(30, Console.CursorTop);
                                Console.Write("Ingrese monto a retirar:");
                                Console.ResetColor();
                                Console.Write(" ");
                                double panqueques = Convert.ToDouble(Console.ReadLine());

                                Cuentonas[posCuentas].retirar(panqueques);

                                Console.Clear();
                                pos = 0;
                                CrearMenu(menuPrincipal, 0);
                                break;
                            }
                        }
                    }
                    if (pos == 2)
                    {
                        Console.Clear();
                        foreach (Cuenta cuentita in Cuentonas){                  
                            Console.WriteLine($"nombre: {cuentita.Titular}, saldo: {cuentita.Cantidad}");
                        }
                        Console.ReadKey(true);

                        Console.Clear();
                        pos = 0;
                        CrearMenu(menuPrincipal, 0);
                    }
                }
            }
        }
    }
}
