using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_9
{
    internal class Sala
    {
        Pelicula pelicula;
        double precio;
        List<Asiento> asientos = new List<Asiento>();

        public Sala(Pelicula pelicula, double precio, List<Asiento> asientos)
        {
            this.pelicula = pelicula;
            this.precio = precio;
            this.asientos = asientos;
        }

        public bool puedeSentarse(Espectador espec, Random rnd) {
            if (espec.Dinero >= precio && espec.Edad >= pelicula.EdadMin && asientos.Count(p => p.ocupado == false) > 0) {
                Asiento asi = asientos.FindAll(p => p.ocupado == false)[rnd.Next(0, asientos.Count(p => p.ocupado == false) - 1)];

                espec.asiento = asi.coordenadasAString();
                asi.ocupado = true;
                return true;
            }

            return false;
        }
    }
}