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
        static void Main(string[] args)
        {
            Random rnd = new Random();

            List<Carta> baraja = new List<Carta>();
            string[] palos = { "oro", "basto", "copa", "espada" };

            for (int i = 1; i <= palos.Length; i++) {                           //
                for (int j = 1; j <= 12; j++) {                                 //
                    if(j != 8 && j!= 9) {                                       //
                        baraja.Add(new Carta(j, palos[i]));                     // Generación de Cartas
                    }                                                           // 
                }                                                               //
            }                                                                   //

            Baraja bar = new Baraja(baraja.ToArray());

            string[] menu = {
                "1. Siguiente carta",
                "2. Cartas disponibles",
                "3. Dar cartas",
                "4. Cartas ya salidas",
                "5. Mostrar baraja",
                "6. Barajar",
                "7. salir"
            };

            Menu.Crear(menu);

            int seleccion = Menu.movilidad(0, menu);

            switch (seleccion)
            {
                case 0:
                    bar.siguienteCarta(); break;
                case 1:
                    bar.cartasDisponibles(); break;
            }
        }
    }
}
