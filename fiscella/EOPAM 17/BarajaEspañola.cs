using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_17
{
    internal class BarajaEspañola : Baraja
    {
        bool truco;
        List<Carta<PalosBarEspañola>> baraja = new List<Carta<PalosBarEspañola>>();

        public BarajaEspañola(bool truco = false) { 
            this.truco = truco;
            crearBaraja();
        }

        public override void crearBaraja()
        {
            for (int i = 0; i < 4; i++) {
                for (int j = 1; j <= 12; j++) {
                    if (!((j == 8 || j == 9) && truco == true)) {
                        baraja.Add(new Carta<PalosBarEspañola>((PalosBarEspañola)i));
                        //Console.WriteLine($"{j} de {Convert.ToString((PalosBarEspañola)i).ToLower()}");
                    }
                }
            }
        }

        public override void mostrarBaraja()
        {
            string nombreTemp;
            for (int i = 0; i < 4; i++) {
                for (int j = 1; j <= 12; j++) {
                    switch (j)
                    {
                        case 1:
                            nombreTemp = "as"; break;
                        case 10:
                            nombreTemp = "sota"; break;
                        case 11:
                            nombreTemp = "caballo"; break;
                        case 12:
                            nombreTemp = "rey"; break;
                        default:
                            nombreTemp = j.ToString(); break;
                    }
                    if (!((j == 8 || j == 9) && truco == true)) {
                        Console.WriteLine($"{nombreTemp} de {Convert.ToString((PalosBarEspañola)i)}");
                    }
                }
            }
        }
    }
}
