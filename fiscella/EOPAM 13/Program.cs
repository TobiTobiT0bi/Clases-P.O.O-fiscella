using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Nos piden hacer una un programa que gestione empleados.
Los empleados se definen por tener:
Nombre
Edad
Salario
También tendremos una constante llamada PLUS, que tendrá un valor de 300€
Tenemos dos tipos de empleados: repartidor y comercial.
El comercial, aparte de los atributos anteriores, tiene uno más llamado comisión (double).
El repartidor, aparte de los atributos de empleado, tiene otro llamado zona (String).
Crea sus constructores, getters and setters (piensa cómo aprovechar la herencia).
No se podrán crear objetos del tipo Empleado (la clase padre) pero sí de sus hijas.
Las clases tendrán un método llamado plus, que según en cada clase tendrá una implementación distinta. Este plus básicamente aumenta el salario del empleado.
En comercial, si tiene más de 30 años y cobra una comisión de más de 200 euros, se le aplicará el plus.
En repartidor, si tiene menos de 25 y reparte en la “zona 3”, este recibirá el plus.
Puedes hacer que devuelva un booleano o que no devuelva nada, lo dejo a tu elección.
Crea una clase ejecutable donde crees distintos empleados y le apliques el plus para comprobar que funciona.

 */
namespace EOPAM_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            List<Comercial> comerciales = new List<Comercial>();
            List<Repartidor> Repartidores = new List<Repartidor>();
            Random rnd = new Random();

            string[] nom = { "Gaspar", "Angie", "Luis", "Sofia", "Tobias", "Claudia" };

            Console.WriteLine("Comerciales: ");
            for (int i = 0; i < 5; i++) {
                comerciales.Add(new Comercial(nom[rnd.Next(0, nom.Length)], rnd.Next(18, 41), rnd.Next(100, 501), rnd.Next(100, 301)));
                Console.WriteLine(comerciales[i].Mostrar());
            }

            Console.WriteLine("\nRepartidores: ");
            for (int i = 0; i < 5; i++)
            {
                Repartidores.Add(new Repartidor(nom[rnd.Next(0, nom.Length)], rnd.Next(18, 41), rnd.Next(100, 501), $"zona {rnd.Next(1, 4)}"));
                Console.WriteLine(Repartidores[i].Mostrar());
            }

            Console.WriteLine("\nPresiona cualquier tecla para aplicar los plus\n\n");
            Console.ReadKey(true);

            Console.WriteLine("Comerciales: ");
            for (int i = 0; i < comerciales.Count(); i++)
            {
                comerciales[i].plus();
                Console.WriteLine(comerciales[i].Mostrar());
            }

            Console.WriteLine("\nRepartidores: ");
            for (int i = 0; i < Repartidores.Count(); i++)
            {
                Repartidores[i].plus();
                Console.WriteLine(Repartidores[i].Mostrar());
            }

            Console.ReadKey(true);
        }
    }
}
