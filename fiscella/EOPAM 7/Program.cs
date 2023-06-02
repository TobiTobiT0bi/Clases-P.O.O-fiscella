using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Vamos a realizar una clase llamada Raíces, donde representaremos los valores de una ecuación de 2º grado.
Tendremos los 3 coeficientes como atributos, llamémosles a, b y c.
Hay que insertar estos 3 valores para construir el objeto.
Las operaciones que se podrán hacer son las siguientes:
obtenerRaices(): imprime las 2 posibles soluciones
obtenerRaiz(): imprime una única raíz, que será cuando solo tenga una solución posible.
getDiscriminante(): devuelve el valor del discriminante (double), el discriminante tiene la siguiente fórmula, (b^2)-4*a*c
tieneRaices(): devuelve un booleano indicando si tiene dos soluciones, para que esto ocurra, el discriminante debe ser mayor o igual que 0.
tieneRaiz(): devuelve un booleano indicando si tiene una única solución, para que esto ocurra, el discriminante debe ser igual que 0.
calcular(): mostrará por consola las posibles soluciones que tiene nuestra ecuación, en caso de no existir solución, mostrarlo también.
Fórmula ecuación 2º grado: (-b±√((b^2)-(4*a*c)))/(2*a)
Solo varía el signo delante de -b
 */
namespace EOPAM_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raices ecuacion;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Ingrese el primer numero (x grado 2)");
                int a = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el segundo numero (x grado 1)");
                int b = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el 3er numero (grado 1)");
                int c = Convert.ToInt32(Console.ReadLine());

                ecuacion = new Raices(a, b, c);

                Console.ReadKey(true);

            }
        }
    }
}
