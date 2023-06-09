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
        List<Carta> original;
        int pos = 0;

        public Baraja(Carta[] baraja) { 
            this.baraja = baraja;
            original = new List<Carta>(baraja);
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

        public List<string> darCartas(int cant) { 
            List<string> seleccion = new List<string>();
            int posinicial = pos;

            for (int i = pos; i < cant + posinicial; i++) {
                seleccion.Add(baraja[i].Mostrar());
                pos++;
            }

            return posinicial + cant > baraja.Length ? null : seleccion;
        }

        public List<string> cartasMonton() {
            List<string> salidas = new List<string>();

            for (int i = 0; i < baraja.Length; i++) {
                salidas.Add(baraja[i].Mostrar());
            }

            salidas.RemoveRange(pos, salidas.Count() - pos);

            return salidas.Count() == 0 ? null : salidas;
        }

        public List<string> mostrarBaraja() {
            List<string> salidas = new List<string>();


            for (int i = 0; i < baraja.Length; i++)
            {
                salidas.Add(baraja[i].Mostrar());
            }
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

        public void reset() {
            baraja = original.ToArray();
        }

        public int Count() {
            return baraja.Length; 
        }

        public int Posicion { 
            get { return pos; }
        }
    }
}
