using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Estando en un grupo de amigos, se planea hacer una porra de la liga de fútbol. A nosotros se nos ocurre hacer un programa en POO para simular cómo podría desarrollarse la apuesta.
Cada jugador que participa de la apuesta, pone un 1 euro para cada jornada y decide el resultado de los partidos acordados.
Si nadie acierta en una jornada los resultados, el pozo se acumula.
En principio, deben acertar el resultado de dos partidos para llevarse el dinero del acumulado de la apuesta.
Todos empiezan con un dinero inicial que será decidido por el programador (ya sea como parámetro o como constante). Si el jugador no tiene dinero en una jornada no podrá participar de la apuesta..
Para esta versión, entre jugadores podrán repetir resultados repetidos, por lo que el jugador que primero diga ese resultado (tal como están de orden) se llevará primero el pozo de dinero.
Los resultados de la apuesta serán generados aleatoriamente, tanto los de jugador como los de los partidos (no es necesario nombre, solo resultados).
Al final del programa, se deberá mostrar el dinero que tienen los jugadores y el número de veces que han ganado.
Para este ejercicio, recomiendo usar interfaces (no hablo de interfaces gráficas) para las constantes y métodos que sean necesarios.
 */

namespace EOPAM_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Persona> amigos = new List<Persona>();
            List<Partido> mundial = new List<Partido>();
            List<string> show = new List<string>(); 
            Random rnd = new Random();

            for (int i = 0; i < 4; i++) { 
                amigos.Add(new Persona(15));
            }

            for (int i = 0; i < 20; i++) {
                mundial.Add(new Partido());
                mundial[i].Ejecutar(rnd);

                for (int j = 0; j < amigos.Count(); j++) {
                    ((IHumano)amigos[j]).Apostar(rnd, mundial[i]);
                    show.Add(amigos[j].Mostrar());
                }

                for (int j = 0; j < amigos.Count(); j++)
                {
                    if (((IHumano)amigos[j]).Comprobar(mundial[i]))
                    {
                        show[j] += " GANADOR";
                        break;
                    }
                }

                Console.WriteLine(string.Join("\n", show));
                Console.WriteLine($"resultado: {mundial[i].resul}");
                Console.ReadKey(true);

                Console.Clear();
                show.Clear();
            }
        }
    }
}
