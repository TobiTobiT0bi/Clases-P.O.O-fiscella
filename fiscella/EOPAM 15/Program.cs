using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using menuTools;

/*

Nos piden hacer un almacén, vamos a usar programación orientada a objetos.
En un almacén se guardan un conjunto de bebidas.
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
Puedes usar un main para probar las funcionalidades (añade productos, calcula precios, muestra información, etc).

*/
namespace EOPAM_15
{
    internal class Program
    {
        static void Main(string[] args) {

            Random rnd = new Random();
            Almacen almacen = new Almacen(5);
            string[] marcas = {"Coca cola company", "PepsiCo", "villavicencio", "Manaos"};
            string[] tipos = { "1. Bebida mineral", "2. Bebida azucarada" };
            string marcaBuscar;
            int estante, posTipos;
            bool salir = false;

            for (int i = 0; i < 30; i++) {
                almacen.agregarProducto(new Mineral(i, Convert.ToSingle(Math.Round(rnd.Next(1, 4) + rnd.NextDouble(), 2)), rnd.Next(100,501), marcas[rnd.Next(0, marcas.Length)], "agua"));
            }
            for (int i = 31; i < 56; i++)
            {
                almacen.agregarProducto(new Azucarada(i, Convert.ToSingle(Math.Round(rnd.Next(1, 4) + rnd.NextDouble(), 2)), rnd.Next(100, 501), marcas[rnd.Next(0, marcas.Length)], rnd.Next(1, 101), Convert.ToBoolean(rnd.Next(0,2))));
            }

            string[] menu = {
            "1. Calcular el precio de todas las bebidas",
            "2. Calcular el precio total de una marca de bebida",
            "3. Calcular el precio total de una estantería",
            "4. Agregar un producto",
            "5. Eliminar un producto",
            "6. Mostrar informacion",
            "7. salir"
            };

            Menu.Crear(menu);

            int id;
            float litros;
            int precio;
            string marca;
            string origen;
            string promoCheck;
            bool promo;
            int porcentajeAzu;


            while (true)
            {
                int pos = Menu.movilidad(menu);

                switch (pos)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"Precio de todos los productos al momento: {almacen.precioTotal()}");
                        Console.ReadKey();

                        Console.Clear();
                        Menu.Crear(menu);
                        break;

                    case 1:
                        Console.Clear();
                        Console.WriteLine("ingrese la marca a buscar.");
                        marcaBuscar = Console.ReadLine();

                        Console.WriteLine($"Precio de todos los productos al momento: {almacen.precioMarca(marcaBuscar)}");
                        Console.ReadKey();

                        Console.Clear();
                        Menu.Crear(menu);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("ingrese la estanteria a buscar.");
                        estante = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"Precio de todos los productos al momento: {almacen.precioEstante(estante)}");
                        Console.ReadKey();

                        Console.Clear();
                        Menu.Crear(menu);
                        break;

                    case 3:
                        Console.Clear();

                        Menu.Crear(tipos);

                        posTipos = Menu.movilidad(tipos);

                        switch (posTipos) {
                            case 0:
                                Console.Clear();
                                Console.WriteLine($"Ingrese ID");
                                id = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine($"Ingrese cantidad de litros");
                                litros = Convert.ToSingle(Console.ReadLine());

                                Console.WriteLine($"Ingrese precio");
                                precio = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine($"Ingrese marca");
                                marca = Console.ReadLine();

                                Console.WriteLine($"Ingrese origen");
                                origen = Console.ReadLine();

                                almacen.agregarProducto(new Mineral(id, litros, precio, marca, origen));
                                Console.Clear();
                                Menu.Crear(menu);
                                break;

                            case 1:
                                Console.Clear();
                                Console.WriteLine($"Ingrese ID");
                                id = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine($"Ingrese cantidad de litros");
                                litros = Convert.ToSingle(Console.ReadLine());

                                Console.WriteLine($"Ingrese precio");
                                precio = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine($"Ingrese marca");
                                marca = Console.ReadLine();

                                Console.WriteLine($"Ingrese porcentaje de azucar");
                                porcentajeAzu = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine($"¿Aplica para promocion? Y/N");
                                promoCheck = Console.ReadLine();
                                promo = promoCheck == "Y" ? true : promoCheck == "y" ? true : false;

                                almacen.agregarProducto(new Azucarada(id, litros, precio, marca, porcentajeAzu, promo));
                                Console.Clear();
                                Menu.Crear(menu);
                                break;
                        }
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Ingrese ID");
                        id = Convert.ToInt32(Console.ReadLine());

                        almacen.eliminarProducto(id);
                        Console.Clear();
                        Menu.Crear(menu);
                        break;

                    case 5:
                        Console.Clear();
                        Console.Write(almacen.mostrarTodo());
                        Console.ReadKey();

                        Console.Clear();
                        Menu.Crear(menu);
                        break;

                    case 6:
                        salir = true;
                        break;
                }

                if (salir == true) break;
            }
        }
    }
}
