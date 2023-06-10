using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_11
{
    internal class Partido : IPartido
    {
        public string resul { get; set; }
        public int pozoAcumulado { get; set; }

        public void Ejecutar(Random rnd)
        {
            resul = $"{rnd.Next(0, 4)} - {rnd.Next(0, 4)}";
        }
    }
}
