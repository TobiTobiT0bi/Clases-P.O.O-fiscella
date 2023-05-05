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
            const string consumoDefecto = "F";
            const string colorDefecto = "blanco"; //constantes
            const int pesoDefecto = 5;

            string[] letrasDisponibles = { "A", "B", "C", "D", "E", "F" };
            string[] coloresDisponibles = { "blanco", "negro", "azul", "rojo", "gris" }; //con esto compruebo que cosas si y que cosas no

            int precio = precioBase;
            string color = colorDefecto;
            string consumoEnergico = consumoDefecto; //todo esto tenia que estar en private, no? porque si lo podiamos poner en public voy a llorar B)
            int peso = pesoDefecto;

            public Electrodomesticos() { }

            public Electrodomesticos(int precio, int peso) {
                this.precio = precio;
                this.peso = peso;
            }
            public Electrodomesticos(int precio, string color, string consumo, int peso) //constructores
            {
                this.precio = precio;
                this.color = color;
                this.consumoEnergico = consumo;
                this.peso = peso;

            }

            void comprobarConsumoEnergico(char letra) {

                bool valido = false;

                for (int i = 0; i < letrasDisponibles.Length; i++) { 
                    if(Convert.ToString(letra) == letrasDisponibles[i]) { valido = true; break; } //compruebo consumo
                }
                if (valido == false) {
                    this.consumoEnergico = consumoDefecto;
                }
            }

            void comprobarColor(string color)
            {

                bool valido = false;

                for (int i = 0; i < coloresDisponibles.Length; i++)
                {
                    if (color.ToLower() == letrasDisponibles[i].ToLower()) { valido = true; break; } //compruebo color
                }
                if (valido == false)
                {
                    this.color = colorDefecto;
                }
            }

            public virtual void PrecioFinal() {
                if (consumoEnergico.ToUpper() == "A") {
                    precio += 100; 
                }
                if (consumoEnergico.ToUpper() == "B")
                {
                    precio += 80;
                }
                if (consumoEnergico.ToUpper() == "C")
                {
                    precio += 60;
                }
                if (consumoEnergico.ToUpper() == "D") //estoy seguro que hay una forma mejor de hacer esto waaaaaaaaaaaaa
                {
                    precio += 50;
                }
                if (consumoEnergico.ToUpper() == "E")
                {
                    precio += 30;
                }
                if (consumoEnergico.ToUpper() == "F")
                {
                    precio += 10;
                }


                if (peso < 0)
                {
                    Console.WriteLine("Cómo puede pesar menos que 0?????");
                    Console.ReadKey();
                }
                if (peso >= 0 && peso <= 19)
                {
                    precio += 10;
                }
                if (peso >= 20 && peso <= 49)
                {
                    precio += 50;
                }
                if (peso >= 50 && peso <= 79)
                {
                    precio += 80;
                }
                if (peso >= 80)
                {
                    precio += 100;
                }

            }

            public int Precio
            {
                get { return this.precio; }
            }

            public string Color { 
                get { return this.color; }
            }

            public string ConsumoEnergico {
                get { return this.consumoEnergico; }
            }

            public string Peso {
                get { return this.Peso; }
            }

        }

        class Lavadora : Electrodomesticos {
            const int cargaDefecto = 5;

            int carga = cargaDefecto;

            public Lavadora(){ }

            public Lavadora(int precio, int peso) {
                this.precio = precio;
                this.peso = peso;
            }

            /* public void Preciofinal() { 
                
            } */

            public int Carga
            {
                get { return this.carga; }
            }
        }

        class Television : Electrodomesticos { 
            const float resolucionDefecto = 20;
            const bool sintonizadorTDTfecto = false;

            float resolucion = resolucionDefecto;
            bool sintonizadorTDT = sintonizadorTDTfecto;

            public Television() { }

            public Television(int precio, int peso) { 
                this.precio = precio;
                this.peso = peso;
            }

        }

        static void Main(string[] args)
        {
            Electrodomesticos[] electrodomesticos = { new Electrodomesticos(100, 50), new Lavadora(200, 40), new Television(50, 30), new Electrodomesticos(110, 75), new Television(150, 42), new Lavadora(100, 53), new Electrodomesticos(80, 10),  new Television(200, 68), new Lavadora(300, 92), new Electrodomesticos(1020, 150)};


        }
    }
}
