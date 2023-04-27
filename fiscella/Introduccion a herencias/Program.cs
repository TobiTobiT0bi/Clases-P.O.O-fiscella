using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion_a_herencias
{
    class Empleado 
    {
        string nom;
        string ape;
        public string Nombre
        {
            get { return nom; } set { this.nom = value; } 
        }
        public string Apellido
        {
            get { return ape; } set { this.ape = value; }
        }
    }

    class Diseñador:Empleado 
    {
    
    }

    class Backend:Empleado 
    {
    
    }

    class FullStack:Empleado 
    {
    
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            Backend b = new Backend();

            b.Nombre = "Elmo";
            b.Apellido = "Mero";

            Console.Write($"quiero probar esta manera de usar strings, el nombre es: {b.Nombre}, el apellido es: {b.Apellido}");
            Console.ReadKey();

        }
    }
}
