using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_7
{
    internal class Raices            // ¿es dificil de leer? esto lo use para practicar ternarios ya que estaba, creo que me emocioné un poco
    {
        int a;
        int b;
        int c;

        double discriminante;

        public Raices(int a, int b, int c) { 
            this.a = a; this.b = b; this.c = c;
            discriminante = getDiscriminante();

            Calcular(discriminante);
        }

        double getDiscriminante() {
            return (b * b) - 4 * a * c;
        }

        public string obtenerRaices(double discriminante) {
            double[] raices = new double[2];

            double cuadrada = Math.Sqrt(discriminante);

            raices[0] = (-b + cuadrada) / (2 * a);
            raices[1] = (-b - cuadrada) / (2 * a);

            return $"raices de {a}x{(b < 0 ? "" : "+")}{b}x{(c < 0 ? "" : "+")}{c}: x1: {raices[0]}, x2: {raices[1]}";
        }

        public string obtenerRaiz(double discriminante)
        {
            double raiz;

            raiz = (-b + Math.Sqrt(discriminante)) / (2 * a);

            return $"raices de {a}x{(b < 0 ? "" : "+")}{b}x{(c < 0 ? "" : "+")}{c}: x1: {raiz}";
        }

        public bool tieneRaices(double discriminante) {
            bool tiene = (discriminante > 0) ? true : false;

            return tiene;
        }

        public bool tieneRaiz(double discriminante)
        {
            bool tiene = (discriminante == 0) ? true : false;

            return tiene;
        }

        public void Calcular(double discriminante)
        {
            Console.WriteLine($"{(tieneRaices(discriminante) ? obtenerRaices(discriminante) : (tieneRaiz(discriminante) ? obtenerRaiz(discriminante) : $"{(a > 0 ? "" : "+")}{a}x{(b < 0 ? "" : "+")}{b}x{(c < 0 ? "" : "+")}{c} no tiene raices reales"))}");
            /* if (discriminante > 0)
            {
                obtenerRaices(discriminante);
            }
            else if (discriminante == 0)
            {
                obtenerRaiz(discriminante);
            }
            else {
                Console.Write($"{(a > 0 ? "" : Convert.ToString(Math.Sign(a)))}{a}{Math.Sign(b)}{b}{Math.Sign(c)}{c} no tiene raices reales");
            } */
        }
    }
}
