using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_8
{
    internal class Profesor : Persona
    {
        public string materia;

        string[] materias = {"matematicas", "filosofia", "fisica"};

        public Profesor(Random rnd) : base(rnd) 
        {
            edad = rnd.Next(21, 66);
            materia = materias[rnd.Next(0, materias.Length)];
            falta = Falta(rnd);
        }

        public override bool Falta(Random rnd)
        {
            bool falta = (rnd.Next(1, 6) == 1);

            return falta;
        }
    }
}
