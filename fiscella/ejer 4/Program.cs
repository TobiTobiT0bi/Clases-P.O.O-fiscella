using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 4. Crear un programa que genere una lista de números primos hasta un número ingresado por el usuario.

namespace ejer_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.SetCursorPosition(30, 12);
            Console.Write("ingrese un numero para generar sus numeros primos.");
            Console.SetCursorPosition(30, 13);

            int num = Convert.ToInt16(Console.ReadLine());
            List<int> primos = new List<int>();
            List<int> divisores = new List<int>();
            divisores.Add(0);

            Console.SetCursorPosition(30, 14);
            Console.CursorVisible = false;

            for (int i = 1; i < num; i++) {

                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        divisores.Add(i);
                    }
                }
                    
                if (divisores.Count == 2)
                {
                    primos.Add(i);
                }

                divisores.Clear();
                divisores.Add(1);
            }

            Console.SetCursorPosition(30, 14);
            Console.Write("numeros primos de {0}: ", num);
            for (int i = 0; i < primos.Count; i++) {
                Console.SetCursorPosition(30, (Console.CursorTop + 1));
                Console.Write(primos[i]);
            }

            Console.ReadKey();
        }
    }
}
