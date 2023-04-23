using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 10. Crear un programa que permita al usuario convertir una cantidad de una unidad de medida a otra, por ejemplo, de metros a pies.

namespace ejer_10
{
    internal class Program
    {
        static void CrearMenu(string[] menu)
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
                else if (i != menu.Length - 1) 
                {
                    Console.SetCursorPosition(30, (i + 8));
                    Console.WriteLine(menu[i]);
                }
            }
        }
        static void Main(string[] args)
        {

            Console.SetCursorPosition(30, 14);
            Console.Write("seleccione 1er unidad de medida.");
            Console.CursorVisible = false;

            ///////////////////////////////////////////////////

            string[] menuPrincipal = {
                " 1. centimetro             ",
                " 2. metro                  ",
                " 3. kilometro              ",
                " 4. easter egg :3          "
            };
            int pos = 0;

            CrearMenu(menuPrincipal);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.DownArrow && pos < 3)
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

                if (key.Key == ConsoleKey.Enter )
                {
                    if (pos != 3) {
                        Console.Clear();
                        Console.SetCursorPosition(30, 12);
                        Console.Write("ingrese cantidad de medida inicial: ");
                        float baseUni = Convert.ToInt16(Console.ReadLine());
                        int posCam = 0;

                        Console.Clear();
                        Console.SetCursorPosition(30, 12);
                        Console.Write("seleccione a que cambiar.");

                        CrearMenu(menuPrincipal);

                        while (true)
                        {
                            ConsoleKeyInfo keyConver = Console.ReadKey(true);

                            if (keyConver.Key == ConsoleKey.DownArrow && posCam < 2)
                            {
                                Console.SetCursorPosition(30, (posCam + 8));
                                Console.WriteLine(menuPrincipal[posCam]);
                                posCam++;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(30, (posCam + 8));
                                Console.WriteLine(menuPrincipal[posCam]);
                                Console.ResetColor();
                            }

                            if (keyConver.Key == ConsoleKey.UpArrow && posCam > 0)
                            {
                                Console.SetCursorPosition(30, (posCam + 8));
                                Console.WriteLine(menuPrincipal[posCam]);
                                posCam--;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(30, (posCam + 8));
                                Console.WriteLine(menuPrincipal[posCam]);
                                Console.ResetColor();
                            }

                            if (keyConver.Key == ConsoleKey.Enter)
                            {
                                if (posCam == 0)
                                {
                                    /*if (pos == 0)
                                    {
                                        baseUni = baseUni;
                                    } */
                                    if (pos == 1)
                                    {
                                        baseUni = baseUni / 100;
                                    }
                                    if (pos == 2)
                                    {
                                        baseUni = baseUni / 100000;
                                    }
                                }
                                if (posCam == 1)
                                {
                                    if (pos == 0)
                                    {
                                        baseUni = baseUni * 100;
                                    }
                                  /*  if (pos == 0)
                                    {
                                        baseUni = baseUni;
                                    } */
                                    if (pos == 2)
                                    {
                                        baseUni = baseUni / 100000;
                                    }
                                }
                                if (posCam == 2)
                                {
                                    if (pos == 0)
                                    {
                                        baseUni = baseUni * 100000;
                                    }
                                    if (pos == 1)
                                    {
                                        baseUni = baseUni * 1000;
                                    }
                                    /* if (pos == 2)
                                    {
                                        baseUni = baseUni * 1000;
                                    } */
                                }

                                Console.SetCursorPosition(30, 12);
                                Console.Write("medida final: " + baseUni + "                              ");
                                Console.ReadKey();
                                break;
                            }
                        }
                            break;
                    }
                    if (pos == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("ESTE ES UN EASTER EGG PQ ESTUVE CERCA DE 8 HORAS HACIENDO EL TRABAJO Y CREO QUE MI \nSANIDAD MENTAL LLEGO A UN ESTADO IRREPARABLE (LOOOOOOOOOOOOOOL NO PENSE Q ME IBA A LLEVAR TANTO)");
                        Console.SetCursorPosition(14, 16);
                        Console.WriteLine("\r\n(つ -‘ _ ‘- )つ");
                        Console.SetCursorPosition(2, 7);
                        Console.WriteLine("mejores canciones de la historia (no es un top) : 1. drift - arc system");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("2. banana man - tally hall");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("3. manicomio - emanero");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("4. amigo - romeo santos");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("5. smell of the game - arc system");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("6. diva of despair - daisuke Ishiwatari");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("7.arcangel - bzrp");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("8. nunca quise - intoxicados");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("9. virtual insanity - jamiroquai");
                        Console.SetCursorPosition(52, Console.CursorTop);
                        Console.WriteLine("10. fluorescent adolescent - Arctic monkeys");
                    }
                }
            }
        }
    }
}
