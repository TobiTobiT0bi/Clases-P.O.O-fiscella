using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_12
{
    internal class Juego {
        List<Jugador> players = new List<Jugador>();
        Revolver revolver;

        public Juego(List<Jugador> p, Revolver r) {
            this.players = p;
            this.revolver = r;
        }

        public bool finJuego() { 
            return players.Count(j => j.Vivo == false) > 0;
        }

        public List<string> ronda() {
            List<string> resultados = new List<string>();

            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].Disparar(revolver))
                {
                    players[i].Vivo = false;
                };
                resultados.Add(players[i].Vivo == true ? $"{players[i].Nombre} se dispara, sobrevive esta ronda" : $"{players[i].Nombre} se dispara, la bala sale y {players[i].Nombre} muere");
                revolver.siguienteBala();
            }

            return resultados;
        }
    }
}
