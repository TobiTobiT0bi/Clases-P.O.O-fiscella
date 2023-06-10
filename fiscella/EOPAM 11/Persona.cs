using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_11
{
    internal class Persona : IHumano
    {
        public int dinero { get; set; }
        public string apuesta { get; set; }
        public int victorias { get; set; }

        public Persona(int dinero) {
            this.dinero = dinero;
        }

        string IHumano.Apostar(Random rnd, Partido partido) {
            //apuesta = dinero >= 1 ? $"{rnd.Next(0, 11)} - {rnd.Next(0 - 11)}" : apuesta; no tiene sentido preguntar 2 veces lo mismo, ademas no se como meter varias lineas en un ternario, creo que ni siquiera se puede
            //dinero = dinero >= 1 ? dinero-- : dinero;

            if (dinero >= 1)
            {
                dinero--;
                apuesta = $"{rnd.Next(0, 3)} - {rnd.Next(0, 3)}";
                partido.pozoAcumulado++;
            }
            else {
                apuesta = "dinero insuficiente";
            }

            return $"{apuesta}";
        }

        bool IHumano.Comprobar(Partido resul) {
            bool ganar = false;

            if (resul.resul == apuesta) {
                victorias++;
                ganar = true;
                if (victorias % 2 == 0)
                {
                    dinero += resul.pozoAcumulado;
                    resul.pozoAcumulado = 0;
                }
            }

            return ganar;
        }

        public string Mostrar(bool yas)
        {
            if (yas == true) {
                return $"dinero: {dinero}, victorias: {victorias}";
            }
            return $"dinero: {dinero}, victorias: {victorias}, apuesta: {apuesta}";
        }
    }
}
