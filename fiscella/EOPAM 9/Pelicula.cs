using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_9
{
    internal class Pelicula
    {
        string titulo;
        double duracion;
        int edadMin;
        string director;

        public Pelicula(string titulo, double duracion, int edadMin, string director)
        {
            this.titulo = titulo;
            this.duracion = duracion;
            this.edadMin = edadMin;
            this.director = director;
        }

        public int EdadMin
        {
            get { return edadMin; }
        }
    }
}
