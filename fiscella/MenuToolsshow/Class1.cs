using System;



namespace MenuToolsshow
{
    public static class movil
    {
        public static void menuMovil(ConsoleKeyInfo key, int pos, string[] menu)
        {
            if (key.Key == ConsoleKey.DownArrow && pos < 3)
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
        }
    }
}