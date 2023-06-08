using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_10
{
    internal class Baraja
    {
        Carta[] baraja = new Carta[40]; //trabajar con una lista hubiera sido mil veces mas facil, pero decia exclusivamente que tenian que ser 40 cartas asi que array de 40 espacios 
        int pos = 0;

        public Baraja(Carta[] baraja) { 
            this.baraja = baraja;
        }

        public Carta siguienteCarta() {
            if (pos < baraja.Length)
            {
                pos++;

                return baraja[pos - 1];
            }
            
            return null;           
        }

        public int cartasDisponibles() {
            return baraja.Length - pos;
        }

        public List<Carta> darCartas(int cant) { 
            List<Carta> seleccion = new List<Carta>(baraja);

            return pos + cant > baraja.Length ? null : seleccion.GetRange(0, cant);
        }

        public List<Carta> cartasMonton() {
            List<Carta> salidas = new List<Carta>();

            salidas.AddRange(baraja);
            salidas.RemoveRange(pos, salidas.Count() - pos);

            return salidas.Count() == 0 ? null : salidas;
        }

        public List<Carta> mostrarBaraja() {
            List<Carta> salidas = new List<Carta>();

            salidas.AddRange(baraja);
            salidas.RemoveRange(0, pos);

            return salidas.Count() == 0 ? null : salidas;
        }
        public void barajar(Random rnd) {
            Carta puente;
            int indiceR;

            for (int i = pos; i < baraja.Length; i++) {
                indiceR = rnd.Next(pos, baraja.Length);
                puente = baraja[i];
                baraja[i] = baraja[indiceR];
                baraja[indiceR] = puente;
            }
        }

        public void mazo(Random rnd)
        {
            pos = 0;
            barajar(rnd);
        }

        public int Posicion { 
            get { return pos; }
        }
    }
}
