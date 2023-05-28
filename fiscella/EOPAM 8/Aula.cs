using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_8
{
    internal class Aula
    {
        public int id;
        public int maxAlumnos = 30;
        public string asignacion;
        public List<Alumno> alumnos = new List<Alumno>();
        public Profesor profe;

        string[] asignaciones = { "matematicas", "filosofia", "fisica" };

        public Aula(int id, List<Alumno> alumnos, Profesor profe, Random rnd)
        {
            this.id = id;
            asignacion = asignaciones[rnd.Next(0, asignaciones.Length)];
            this.alumnos = alumnos;
            this.profe = profe;
        }

        public string claseApta() {
            List<Alumno> aprobados = new List<Alumno>();

            if (profe.falta == false && alumnos.Count(p => p.falta == true) < (alumnos.Count / 2) && profe.materia == asignacion)
            {
                aprobados = alumnos.FindAll(alu => alu.calificacion >= 6);

                return $"cantidad de alumnos hombres aprobados: {aprobados.Count(apro => apro.sexo == "Masculino")} \n   cantidad de alumnas mujeres aprobadas: {aprobados.Count(apro => apro.sexo == "Femenino")}";
            }
            else {
                return "la clase no es apta para iniciar";
                //return $"la clase no es apta para iniciar, profe falta: {profe.falta}, cantidad alumnos ausentes : {alumnos.Count(p => p.falta == true)}, alumnos totales: {alumnos.Count}, profesor materia: {profe.materia}, aula materia: {asignacion}";
            }
        } 
    }
}
