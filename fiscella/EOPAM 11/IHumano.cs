using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_11
{
    internal interface IHumano
    {
        int dinero { get; set; }
        string apuesta { get; set; }
        int victorias { get; }

        string Apostar(Random rnd, Partido par);

        bool Comprobar(Partido resul);
    }
}
