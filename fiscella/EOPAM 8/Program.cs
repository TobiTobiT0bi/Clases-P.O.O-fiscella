using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Queremos representar con programación orientada a objetos, un aula con estudiantes y un profesor.
Tanto de los estudiantes como de los profesores necesitamos saber su nombre, edad y sexo. De los estudiantes, queremos saber también su calificación actual (entre 0 y 10) y del profesor que materia da.
Las materias disponibles son matemáticas, filosofía y física.
Los estudiantes tendrán un 50% para no ir a clase, por lo que sí hacen faltazo no van a clase pero aunque no vayan quedará registrado en el aula (como que cada uno tiene su sitio).
El profesor tiene un 20% de no encontrarse disponible (reuniones, baja, etc.)
Las dos operaciones anteriores deben llamarse igual en Estudiante y Profesor (polimorfismo).
El aula debe tener un identificador numérico, el número máximo de estudiantes y para que está destinada (matemáticas, filosofía o física). Piensa que más atributos necesita.
Un aula para que se pueda dar clase necesita que el profesor esté disponible, que el profesor de la materia correspondiente esté en el aula correspondiente (un profesor de filosofía no puede dar en un aula de matemáticas) y que haya más del 50% de alumnos.
El objetivo es crear un aula de alumnos y un profesor y determinar si puede darse clase, teniendo en cuenta las condiciones antes dichas.
Si se puede dar clase mostrar cuántos alumnos y alumnas (por separado) están aprobados de momento (imaginad que les están entregando las notas).
NOTA: Los datos pueden ser aleatorios (nombres, edad, calificaciones, etc.) siempre y cuando tengan sentido (edad no puede ser 80 en un estudiante o calificación ser 12).
*/

namespace EOPAM_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Aula> salones = new List<Aula>();
            List<Alumno> alus = new List<Alumno>();

            for (int i = 1; i < 330; i++)
            {
                alus.Add(new Alumno(rnd));

                if (i % 30 == 0 && i != 0) {
                    salones.Add(new Aula(i - (29 * (i / 30)), alus, new Profesor(rnd), rnd)); //encuentra la falla
                    Console.WriteLine($"{i/30}. {salones[(i / 30) - 1].claseApta()}\n");
                    alus.Clear();
                }    
            }
            Console.ReadKey(true);
        }
    }
}
