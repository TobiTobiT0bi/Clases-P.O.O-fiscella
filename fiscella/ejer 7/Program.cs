using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ejer_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int>();

            Console.SetCursorPosition(30, 12);
            Console.Write("ingrese 5 numeros.");

            ///////////////////////////////////////////////////
            
            Console.SetCursorPosition(30, 13);
            Console.Write("número 1 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ResetColor();
            numeros.Add(Convert.ToInt32(Console.ReadLine()));

            ///////////////////////////////////////////////////
            
            Console.SetCursorPosition(30, 14);
            Console.Write("número 2 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ResetColor();
            numeros.Add(Convert.ToInt32(Console.ReadLine()));

            ///////////////////////////////////////////////////

            Console.SetCursorPosition(30, 15);
            Console.Write("número 3 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ResetColor();
            numeros.Add(Convert.ToInt32(Console.ReadLine()));

            ///////////////////////////////////////////////////

            Console.SetCursorPosition(30, 16);
            Console.Write("número 4 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ResetColor();
            numeros.Add(Convert.ToInt32(Console.ReadLine()));

            ///////////////////////////////////////////////////

            Console.SetCursorPosition(30, 17);
            Console.Write("número 5 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ResetColor();
            numeros.Add(Convert.ToInt32(Console.ReadLine()));

            ///////////////////////////////////////////////////

            numeros.Sort();

            Console.SetCursorPosition(30, 20);
            Console.Write("número más grande: " + numeros[numeros.Count - 1]);

            Console.SetCursorPosition(30, 21);
            Console.Write("número más pequeño: " + numeros[0]);

            Console.ReadKey();
        }
    }
}
