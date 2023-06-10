using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_11
{
    internal interface IPartido
    {
        string resul { get; set; }
        int pozoAcumulado { get; set; }

        void Ejecutar(Random rnd);
    }
}
