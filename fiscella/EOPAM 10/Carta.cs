using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_10
{
    internal class Carta
    {
        int numero;
        string palo;
        

        public Carta(int numero, string palo)
        {
            this.numero = numero;
            this.palo = palo;
        }

        public string Mostrar()
        {
            return $"{numero} de {palo}";
        }
    }
}
