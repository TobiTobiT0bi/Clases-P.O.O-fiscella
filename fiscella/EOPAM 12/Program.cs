using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Vamos a hacer el juego de la ruleta rusa en Java.
Como muchos sabéis, se trata de un número de jugadores que con un revólver con un sola bala en el tambor se dispara en la cabeza.
Las clases a hacer son:
Revolver:
Atributos:
posición actual (posición del tambor donde se dispara, puede que esté la bala o no)
posición bala (la posición del tambor donde se encuentra la bala)
Estas dos posiciones, se generarán aleatoriamente.
Funciones:
disparar(): devuelve true si la bala coincide con la posición actual
siguienteBala(): cambia a la siguiente posición del tambor
Jugador:
Atributos
id (representa el número del jugador, empieza en 1)
nombre (Empezara con Jugador más su ID, «Jugador 1» por ejemplo)
vivo (indica si está vivo o no el jugador)
Funciones:
disparar(Revólver r): el jugador se apunta y se dispara, si la bala se dispara, el jugador muere.
Juego:
Atributos:
Jugadores (conjunto de Jugadores)
Revolver
Funciones:
finJuego(): cuando un jugador muere, devuelve true
ronda(): cada jugador se apunta y se dispara, se informará del estado de la partida (El jugador se dispara, no ha muerto en esa ronda, etc.)
El número de jugadores será decidido por el usuario, pero debe ser entre 1 y 6. Si no está en este rango, por defecto será 6.
En cada turno uno de los jugadores, dispara el revólver, si este tiene la bala  el jugador muere y el juego termina.
Aunque no lo haya comentado, recuerda usar una clase ejecutable para probarlo.

 */
namespace EOPAM_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("introduzca el numero de jugadores (por defecto 6): ");
            int cantPlayers;

            try
            {
                cantPlayers = Convert.ToInt32(Console.ReadLine());
            }
            catch { 
                cantPlayers = 6;
            }
            
            Random rnd = new Random();

            Revolver revo = new Revolver(rnd);
            List<Jugador> jugadores = new List<Jugador>();
            List<string> ronda = new List<string>();

            for (int i = 0; i < cantPlayers; i++) {
                jugadores.Add(new Jugador(i + 1));
            }

            Juego ruleta = new Juego(jugadores, revo);

            while (true)
            {
                Console.Clear();
                ronda.Clear();
                ronda = ruleta.ronda();

                for (int i = 0; i < ronda.Count(); i++) {
                    Console.SetCursorPosition(30, 10 + i);
                    Console.Write(ronda[i]);
                }

                Console.ReadKey(true);

                if (ruleta.finJuego()) {
                    break;
                }
            }
        }
    }
}
