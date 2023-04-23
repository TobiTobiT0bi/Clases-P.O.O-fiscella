using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1. Crear un programa que calcule el promedio de un conjunto de números ingresados por el usuario.

namespace ejer_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetCursorPosition(30, 12);
            Console.Write("¿Cuantos numeros quiere ingresar?");
            Console.SetCursorPosition(30, 13);

            int cant = Convert.ToInt16(Console.ReadLine());
            int suma = 0;
            Console.SetCursorPosition(30, 14);
            Console.CursorVisible = false;

            if (cant == 1) {
                Console.Write("ingrese el primer numero: ");
                suma = Convert.ToInt16(Console.ReadLine());
            }
            for (int i = 0; i < (cant - 1); i++) {
                if (i == 0) {
                    Console.Write("ingrese el primer numero: ");
                    suma = Convert.ToInt16(Console.ReadLine());
                }
                Console.SetCursorPosition(30, (i + 15));
                Console.Write("Ingrese el siguiente numero: ");
                suma += Convert.ToInt16(Console.ReadLine());
            }

            Console.SetCursorPosition(30, Console.CursorTop);
            Console.Write("el promedio de numeros es: " + (suma / cant));
            Console.ReadKey();
        }
    }
}
