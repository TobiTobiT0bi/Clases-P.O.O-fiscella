using System;

namespace menuTools
{
    public abstract class Menu
    {
        public static void Crear(string[] menu, int nivelado = 30)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < menu.Length; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(nivelado, 8);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(nivelado, (i + 8));
                    Console.WriteLine(menu[i]);
                }
            }
        }

        public static void Crear(string[] menu, int avance, int nivelado = 30)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < menu.Length; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(nivelado, 8 + avance);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(nivelado, (i + 8) + avance);
                    Console.WriteLine(menu[i]);
                }
            }
        }

        public static int movilidad(string[] menu, int pos = 0, int nivelado = 30)
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);               

                if (key.Key == ConsoleKey.DownArrow && pos < menu.Length)
                {
                    if (pos == menu.Length - 1)
                    {
                        Console.SetCursorPosition(nivelado, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        pos = 0;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(nivelado, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.SetCursorPosition(nivelado, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        pos++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(nivelado, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        Console.ResetColor();
                    }
                }

                if (key.Key == ConsoleKey.UpArrow && pos >= 0)
                {
                    if (pos == 0)
                    {
                        Console.SetCursorPosition(nivelado, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        pos = menu.Length - 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(nivelado, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.SetCursorPosition(nivelado, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        pos--;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(nivelado, (pos + 8));
                        Console.WriteLine(menu[pos]);
                        Console.ResetColor();
                    }
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    return pos;
                }
            }
        }
    }
}
