using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_9
{
    internal class Asiento
    {
        int fila;
        char columna;
        public bool ocupado = false;

        public Asiento(int fila, char columna)
        {
            this.fila = fila;
            this.columna = columna;
        }

        public string coordenadasAString() {
            return $"{fila} {columna}";
        }
        public int Fila
        {
            get { return fila; }
        }
    }
}