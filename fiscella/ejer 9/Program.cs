using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 9. Crear un programa que permita al usuario calcular la distancia entre dos puntos en un plano cartesiano.

namespace ejer_9
{
    internal class Program
    {
        static float matematicasEpicas(List<int> x, List<int> y) {

            int mod1 = (x[0] - x[1]) * (x[0] - x[1]);
            int mod2 = (y[0] - y[1]) * (y[0] - y[1]);

            int raiz = mod1 + mod2;

            double distancia = Math.Sqrt(raiz);

            return Convert.ToSingle(Math.Round(distancia, 2));
        }
        static void Main(string[] args)
        {
            List<int> x = new List<int>();
            List<int> y = new List<int>();

            ///////////////////////////////////////////////////

            Console.SetCursorPosition(30, 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("ingrese coordenada x del numero 1: ");
            
            Console.ResetColor();
            x.Add(Convert.ToInt32(Console.ReadLine()));

            ///////////////////////////////////////////////////

            Console.SetCursorPosition(30, 14);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("ingrese coordenada y número 1: ");
            
            Console.ResetColor();
            y.Add(Convert.ToInt32(Console.ReadLine()));

            ///////////////////////////////////////////////////

            Console.SetCursorPosition(30, 15);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("ingrese coordenada x del número 2: ");
            
            Console.ResetColor();
            x.Add(Convert.ToInt32(Console.ReadLine()));

            ///////////////////////////////////////////////////

            Console.SetCursorPosition(30, 16);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("ingrese coordenada y del número 2: ");
            
            Console.ResetColor();
            y.Add(Convert.ToInt32(Console.ReadLine()));

            ///////////////////////////////////////////////////

            float distancia = matematicasEpicas(x, y);

            Console.SetCursorPosition(30, 20);
            Console.Write("distancia entre esos dos puntos: " + distancia);

            Console.ReadKey();
        }
    }
}
