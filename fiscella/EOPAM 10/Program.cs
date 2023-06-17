using System;
using System.Collections.Generic;
using menuTools;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Vamos a hacer una baraja de cartas españolas orientado a objetos.
Una carta tiene un número entre 1 y 12 (el 8 y el 9 no los incluimos) y un palo (espadas, bastos, oros y copas)
La baraja estará compuesta por un conjunto de cartas, 40 exactamente.
Las operaciones que podrá realizar la baraja son:
barajar(): cambia de posición todas las cartas aleatoriamente
siguienteCarta(): devuelve la siguiente carta que está en la baraja, cuando no haya más o se haya llegado al final, se indica al usuario que no hay más cartas.
cartasDisponibles(): indica el número de cartas que aún puede repartir
darCartas(): dado un número de cartas que nos pidan, le devolveremos ese número de cartas (piensa que puedes devolver). En caso de que haya menos cartas que las pedidas, no devolveremos 
nada pero debemos indicarlo al usuario.
cartasMonton(): mostramos aquellas cartas que ya han salido, si no ha salido ninguna indicárselo al usuario
mostrarBaraja(): muestra todas las cartas hasta el final. Es decir, si se saca una carta y luego se llama al método, este no mostrará esa primera carta. 
*/

namespace EOPAM_10
{
    internal class Program
    {
        static void ejecutarBaraja(Carta carta, string msjTrue, string msjFalse, int pos = 12)
        {
            if (carta != null)
            {
                Console.SetCursorPosition(70, pos);
                Console.Write("                                              ");
                Console.SetCursorPosition(70, pos);
                Console.Write($"{msjTrue}{carta.Mostrar()}.");
            }
            else
            {
                Console.SetCursorPosition(70, pos);
                Console.Write("                                              ");
                Console.SetCursorPosition(70, pos);
                Console.WriteLine($"{msjFalse}");
            }
        }

        static void ejecutarBaraja(List<string> bar, string msjFalse, int pos = 12)
        {
            if (bar != null)
            {
                Console.SetCursorPosition(70, pos);
                Console.Write("                                              ");
                Console.SetCursorPosition(70, pos);
                // Console.Write(string.Join("\n", bar)); no sirve pa ordenar :(

                for (int i = 0; i < bar.Count(); i++) {
                    Console.SetCursorPosition(70, pos + i);
                    Console.Write(bar[i]);
                }
            }
            else
            {
                Console.SetCursorPosition(70, pos);
                Console.Write("                                              ");
                Console.SetCursorPosition(70, pos);
                Console.WriteLine($"{msjFalse}");
            }
        }

        static void wipe() {
            Console.SetCursorPosition(70, 12);
            Console.Write("                                                     ");
            Console.SetCursorPosition(70, 12);
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Carta cartaTemp;
            int pos = 0;

            List<Carta> baraja = new List<Carta>();
            string[] palos = { "oro", "basto", "copa", "espada" };

            for (int i = 0; i < palos.Length; i++) {                            //
                for (int j = 1; j <= 12; j++) {                                 //
                    if(j != 8 && j!= 9) {                                       //
                        baraja.Add(new Carta(j, palos[i]));                     // Generación de Cartas
                    }                                                           // 
                }                                                               //
            }                                                                   //

            Baraja bar = new Baraja(baraja.ToArray());

            string[] menu = {
                "1. Siguiente carta    ",
                "2. Cartas disponibles ",
                "3. Dar cartas         ",
                "4. Cartas ya salidas  ",
                "5. Mostrar baraja     ",
                "6. Barajar            ",
                "7. volver a mezclar   ",
                "8. resetear           ",
                "9. salir             "
            };

            Menu.Crear(menu, 30);

            Console.SetCursorPosition(70, 10);
            Console.WriteLine($"Cartas en la baraja originalmente: {bar.Count()}");

            while (true)
            {
                int seleccion = Menu.movilidad(menu, pos);
                bool salir = false;

                switch (seleccion)
                {
                    case 0:
                        //cartaTemp = bar.siguienteCarta() != null ? Console.Write($"La carta salida es: a.") : Console.WriteLine("No hay mas cartas en la baraja.");    CS0029: No se puede convertir implicitamente el tipo 'void' en 'EOPAM_10.Carta' {buscar despues!!!}

                        cartaTemp = bar.siguienteCarta();

                        ejecutarBaraja(cartaTemp, "La carta salida es: ", "No hay mas cartas en la baraja.");

                        pos = 0; break;

                    case 1:
                        wipe();
                        Console.WriteLine($"cartas disponibles: {bar.cartasDisponibles()}");
                        pos = 1; break;
                    case 2:
                        Console.SetCursorPosition(70, 12);
                        Console.WriteLine("ingrese la cantidad de cartas que quiere sacar");
                        Console.SetCursorPosition(70, 13);
                        int cant = Convert.ToInt32(Console.ReadLine());

                        ejecutarBaraja(bar.darCartas(cant), "Cartas insuficientes en el mazo.");

                        Console.SetCursorPosition(70, 8);
                        Console.Write("(Presiona cualquier tecla para reiniciar)");
                        Console.ReadKey(true);
                        Console.Clear();

                        Menu.Crear(menu, 30);

                        Console.SetCursorPosition(70, 10);
                        Console.WriteLine($"Cartas en la baraja originalmente: {bar.Count()}");

                        pos = 0; break;
                    case 3:
                        ejecutarBaraja(bar.cartasMonton(), "Todavia no a salido ninguna carta.");

                        Console.SetCursorPosition(70, 8);
                        Console.Write("(Presiona cualquier tecla para reiniciar)");
                        Console.ReadKey(true);
                        Console.Clear();

                        Menu.Crear(menu, 30);

                        Console.SetCursorPosition(70, 10);
                        Console.WriteLine($"Cartas en la baraja originalmente: {bar.Count()}");

                        pos = 0; break;
                    case 4:
                        ejecutarBaraja(bar.mostrarBaraja(), "Han salido todas las cartas.");

                        Console.SetCursorPosition(70, 8);
                        Console.Write("(Presiona cualquier tecla para reiniciar)");
                        Console.ReadKey(true);
                        Console.Clear();

                        Menu.Crear(menu, 30);

                        Console.SetCursorPosition(70, 10);
                        Console.WriteLine($"Cartas en la baraja originalmente: {bar.Count()}");

                        pos = 0; break;
                    case 5:
                        wipe();
                        Console.WriteLine("barajando...");
                        bar.barajar(rnd);
                        wipe();
                        Console.WriteLine("mazo barajado.");

                        pos = 5; break;
                    case 6:
                        wipe();
                        Console.WriteLine("mezclando");
                        bar.mazo(rnd);
                        wipe();
                        Console.WriteLine("mazo rehecho.");

                        pos = 6; break;
                    case 7:
                        wipe();
                        Console.WriteLine("Restaurando");
                        bar.reset();
                        wipe();
                        Console.WriteLine("mazo reseteado.");

                        pos = 7; break;
                    case 8:
                        salir = true;
                        pos = 0; break;
                }

                if (salir == true) break;
            }
            
        }
    }
}
