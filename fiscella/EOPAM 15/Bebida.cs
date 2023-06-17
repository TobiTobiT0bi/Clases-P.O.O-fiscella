using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_15
{
    internal class Bebida
    {
        int identificador;
        float cantLitros;
        float precio;
        string marca;

        public Bebida(int identificador, float cantLitros, float precio, string marca) { 
            this.identificador = identificador;
            this.cantLitros = cantLitros;
            this.precio = precio;
            this.marca = marca;
        }

        public virtual float Precio {
            get { return precio; }
        }

        public string Marca { 
            get { return marca; }
        }

        public int Identificador {
            get { return identificador; }
        }

        public virtual string Mostrar() {
            return $"identificador: {identificador}, litros: {cantLitros}, precio: {precio}, marca: {marca}";
        }
    }
}
