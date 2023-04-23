using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 3.Crear un programa que simule un juego de adivinanza de números, en el que el usuario debe adivinar un número generado aleatoriamente por el programa.

namespace ejer_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            while (true) {
                Console.Clear();
                int numerito = rnd.Next(0, 10);
                Console.SetCursorPosition(30, 8);
                Console.WriteLine("Adivina el numero del 1 al 10 (LoL)");
                Console.SetCursorPosition(30, 9);
                int adivinador = 0;
                bool pass = false;

                try {
                    adivinador = Convert.ToInt16(Console.ReadLine());
                    pass = true;
                }
                catch (Exception ex)
                {
                    Console.SetCursorPosition(30, 10);
                    Console.WriteLine("escribi un numero valido no seas malo :c");
                }

                if (adivinador == numerito && pass == true)
                {
                    Console.SetCursorPosition(30, 12);
                    Console.WriteLine("Adivinaste wow! :D");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.SetCursorPosition(30, 12);
                    Console.WriteLine("No adivinaste intenta de vuelta jej");
                    Console.ReadKey();
                }
            }            
        }
    }
}
