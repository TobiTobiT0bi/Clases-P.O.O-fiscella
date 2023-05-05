using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_ejer_4
{
    internal class Program
    {
        class Electrodomesticos {
            const int precioBase = 100;

            int precio = precioBase;
            string color = "blanco";
            string consumoEnergico = "F";
            int peso = 5;

            public Electrodomesticos() { }

            public Electrodomesticos(int precio, int peso) { 
                this.precio = precio;
                this.peso = peso;
            }
            public Electrodomesticos(int precio, string color, string consumo, int peso)
            {
                this.precio = precio;
                this.color = color;
                this.consumoEnergico = consumo;
                this.peso = peso;

            }
        }

        class Lavadora : Electrodomesticos { 
            
        }
        static void Main(string[] args)
        {



        }
    }
}
