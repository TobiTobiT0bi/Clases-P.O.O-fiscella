using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_chati_1
{
    internal class Menu
    {
        public void Crear(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(30, 8);
                    Console.ForegroundColor = ConsoleColor.Green;
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

        public void Crear(string[] menu, int avance)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(30, 8 + avance);
                    Console.ForegroundColor = ConsoleColor.Green;
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

        public int movilidad(int pos, string[] menu)
        {
            while (true)
            {
                Console.CursorVisible = false;
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.DownArrow && pos <= (menu.Length - 1))
                {
                    if (pos == (menu.Length - 1))
                    {
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        pos = 0;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        Console.ResetColor();
                    }
                    else {
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        pos++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        Console.ResetColor();
                    }
                }

                if (key.Key == ConsoleKey.UpArrow && pos >= 0)
                {
                    if (pos == 0)
                    {
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        pos = menu.Length - 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        Console.ResetColor();
                    }
                    else {
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        pos--;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(30, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        Console.ResetColor();
                    }
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = true;
                    return pos;
                }
            }
        }
    }
}
