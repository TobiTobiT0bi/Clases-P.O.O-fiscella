using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Vamos a hacer unas mejoras a la clase Baraja del ejercicio 5 de POO de los videos.
Lo primero que haremos es que nuestra clase Baraja será la clase padre y será abstracta.
Le añadiremos el número de cartas en total y el número de cartas por palo.
El método crearBaraja() será abstracto.
La clase Carta tendrá un atributo genérico que será el palo de nuestra versión anterior.
Creamos dos Enum:
PalosBarEspañola:
OROS
COPAS
ESPADAS
BASTOS
PalosBarFrancesa:
DIAMANTES
PICAS
CORAZONES
TREBOLES
Creamos dos clases hijas:
BarajaEspañola: tendrá un atributo booleano para indicar si queremos jugar con las cartas 8 y 9 (total 48 cartas) o no (total 40 cartas).
BarajaFrancesa: no tendrá atributos, el total de cartas es 52 y el número de cartas por palo es de 13. Tendrá dos métodos llamados:
cartaRoja(Carta<PalosBarFrancesa> c): si el palo es de corazones y diamantes.
cartaNegra(Carta<PalosBarFrancesa> c): si el palo es de tréboles y picas.
Si el palo es de tipo PalosBarFrancesa:
La carta número 11 será Jota
La carta número 12 será Reina
La carta número 13 será Rey
La carta número 1 será As
Si el palo es de tipo PalosBarEspañola:
La carta número 10 será Sota
La carta número 12 será Caballo
La carta número 13 será Rey
La carta número 1 será As

 */
namespace EOPAM_17
{
    enum PalosBarEspañola { OROS, COPAS, ESPADAS, BASTOS }
    enum PalosBarFrancesa { DIAMANTES, PICAS, CORAZONES, TREBOLES}

    internal class Program
    {
        static void Main(string[] args)
        {
            BarajaEspañola españolaTruco = new BarajaEspañola(true);
            BarajaEspañola españolaEnvido = new BarajaEspañola();

            BarajaFrancesa segunda = new BarajaFrancesa();

            españolaTruco.crearBaraja();
            españolaEnvido.crearBaraja();
            segunda.crearBaraja();

            Console.WriteLine("BARAJA ESPAÑOLA SIN 8 Y 9\n");
            españolaTruco.mostrarBaraja();

            Console.WriteLine("\n\n\nBARAJA ESPAÑOLA POR DEFECTO\n");
            españolaEnvido.mostrarBaraja();

            Console.WriteLine("\n\n\nBARAJA FRANCESA\n");
            segunda.mostrarBaraja();

            Console.ReadKey();
        }
    }
}
