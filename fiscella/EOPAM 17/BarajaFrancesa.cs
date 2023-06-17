using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_17
{
    internal class BarajaFrancesa : Baraja
    {
        List<Carta<PalosBarFrancesa>> baraja = new List<Carta<PalosBarFrancesa>>();

        public BarajaFrancesa()
        {
            crearBaraja();
        }

        public override void crearBaraja()
        {
            for (int i = 0; i < 4; i++) {
                for (int j = 1; j <= 13; j++)
                {
                    baraja.Add(new Carta<PalosBarFrancesa>((PalosBarFrancesa)i));
                }
            }
        }

        public bool cartaRoja(Carta<PalosBarFrancesa> c) {
            return (c.MostrarPalo() == "CORAZONES" || c.MostrarPalo() == "DIAMANTES") ? true : false;
        }

        public bool cartaNegra(Carta<PalosBarFrancesa> c)
        {
            return (c.MostrarPalo() == "TREBOLES" || c.MostrarPalo() == "PICAS") ? true : false;
        }

        public override void mostrarBaraja()
        {
            string nombreTemp;
            for (int i = 0; i < 4; i++) {
                for (int j = 1; j <= 13; j++)
                {
                    switch (j)
                    {
                        case 1:
                            nombreTemp = "As"; break;
                        case 11:
                            nombreTemp = "Jota"; break;
                        case 12:
                            nombreTemp = "Reina"; break;
                        case 13:
                            nombreTemp = "Rey"; break;
                        default:
                            nombreTemp = j.ToString(); break;
                    }
                    Console.WriteLine($"{nombreTemp} de {baraja[j + (i * 13) - 1].MostrarPalo()}, carta {(cartaRoja(baraja[j + (i * 13) - 1]) ? "roja" : (cartaNegra(baraja[j + (i * 13) - 1]) ? "negra" : "acá no deberia llegar nunca pero de alguna manera queria utilizar los dos metodos"))}");
                }
            }
        }
    }
}
