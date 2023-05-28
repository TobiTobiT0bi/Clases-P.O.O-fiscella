using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_8
{
    internal class Alumno : Persona
    {
        public int calificacion;

        public Alumno(Random rnd) : base(rnd)
        {
            edad = rnd.Next(16, 22);
            calificacion = rnd.Next(0, 11);
        }
    }
}
