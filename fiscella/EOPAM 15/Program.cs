using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using menuTools;

/*
Nos piden hacer un almacén, vamos a usar programación orientada a objetos.
En un almacén se guardan un conjunto de  bebidas.
Estos productos son bebidas como agua mineral y bebidas azucaradas (coca-cola, fanta, etc). De los productos nos interesa saber su identificador (cada uno tiene uno distinto), cantidad de litros, precio y marca.
Si es agua mineral nos interesa saber también el origen (manantial tal sitio o donde sea).
Si es una bebida azucarada queremos saber el porcentaje que tiene de azúcar y si tiene o no alguna promoción (si la tiene tendrá un descuento del 10% en el precio).
En el almacén iremos almacenando estas bebidas por estanterías (que son las columnas de la matriz).
Las operaciones del almacén son las siguientes:
Calcular el precio de todas las bebidas: calcula el precio total de todos los productos del almacén.
Calcular el precio total de una marca de bebida: dada una marca, calcular el precio total de esas bebidas.
Calcular el precio total de una estantería: dada una estantería (columna) calcular el precio total de esas bebidas.
Agregar producto: agregar un producto en la primera posición libre, si el identificador está repetido en alguna de las bebidas, no se agrega esa bebida.
Eliminar un producto: dado un ID, eliminar el producto del almacén.
Mostrar información: mostramos para cada bebida toda su información.
Puedes usar un main para probar las funcionalidades (añade productos, calcula precios, muestra información, etc)

*/
namespace EOPAM_15
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] cosas = { 
                "1. a",
                "2. b",
                "3. c"
            };

            Menu.Crear(cosas);

            Menu.movilidad(cosas);

            Console.ReadKey();
        }
    }
}
