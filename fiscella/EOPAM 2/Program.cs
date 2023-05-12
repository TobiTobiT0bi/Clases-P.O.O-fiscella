using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/* 
2) Haz una clase llamada Persona que siga las siguientes condiciones:
Sus atributos son: nombre, edad, DNI, sexo (H hombre, M mujer), peso y altura. No queremos que se accedan directamente a ellos. Piensa que modificador de acceso es el más adecuado, también su tipo. 
Si quieres añadir algún atributo puedes hacerlo. Por defecto, todos los atributos menos el DNI serán valores por defecto según su tipo (0 números, cadena vacía para String, etc.).
Sexo sera hombre por defecto, usa una constante para ello.
Se implantaran varios constructores:
Un constructor por defecto.
Un constructor con el nombre, edad y sexo, el resto por defecto.
Un constructor con todos los atributos como parámetro.
Los métodos que se implementarán son:
calcularIMC(): calculará si la persona está en su peso ideal (peso en kg/(altura^2 en m)), si esta fórmula devuelve un valor menor que 20, la función devuelve un -1, si devuelve un número entre 20 y 25 (incluidos),
significa que está por debajo de su peso ideal la función devuelve un 0 y si devuelve un valor mayor que 25 significa que tiene sobrepeso, la función devuelve un 1. Te recomiendo que uses constantes para devolver estos valores.
esMayorDeEdad(): indica si es mayor de edad, devuelve un booleano.
comprobarSexo(char sexo): comprueba que el sexo introducido es correcto. Si no es correcto, será H. No será visible al exterior.
generaDNI(): genera un número aleatorio de 8 cifras, genera a partir de este su número su letra correspondiente. Este método será invocado cuando se construya el objeto. Puedes dividir el método para que te sea más fácil. 
No será visible al exterior.
Métodos set de cada parámetro, excepto de DNI.
Ahora, crea una clase ejecutable que haga lo siguiente:
Pide por teclado el nombre, la edad, sexo, peso y altura.
Crea 3 objetos de la clase anterior, el primer objeto obtendrá las anteriores variables pedidas por teclado, el segundo objeto obtendrá todos los anteriores menos el peso y la altura y el último por defecto,
para este último utiliza los métodos set para darle a los atributos un valor.
Para cada objeto, deberá comprobar si está en su peso ideal, tiene sobrepeso o por debajo de su peso ideal con un mensaje.
Indicar para cada objeto si es mayor de edad.
Por último, mostrar la información de cada objeto.
Puedes usar métodos en la clase ejecutable, para que os sea mas fácil.
*/

namespace EOPAM_2
{
    public class Persona {
        char[] sexos = {
            'H',
            'M'
        };

        const char panqueques = 'H';
        static Random rnd = new Random();

        private string nombre = "";
        private int edad = 0;
        private string DNI = "";
        private char sexo = panqueques;
        private double peso = 0;
        private double altura = 0;
        

        public Persona() { GenerarDNI(); ComprobarSexo(sexo); }

        public Persona(string nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;

            GenerarDNI();
            ComprobarSexo(sexo);
        }

        public Persona(string nombre, int edad, char sexo, double peso, double altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
            this.peso = peso;
            this.altura = altura;

            GenerarDNI();
            ComprobarSexo(sexo);
        }

        public int calcularIMC()
        {
            double Imc = this.peso / (this.altura * this.altura);

            const int imposible = -2;
            const int sub = -1;
            const int ideal = 0;
            const int sobre = 1;

            if (Imc < 0)
            {
                Console.Write("Cómo??????????????????");
                return imposible;
            }
            else if (Imc < 20)
            {
                return sub;
            }
            else if (Imc >= 20 && Imc <= 25)
            {
                return ideal;
            }
            else
            {
                return sobre;
            }
        }

        public bool esMayorDeEdad() {

            bool Result = false;

            if (this.edad >= 18)
            {
                Result = true;
            }

            return Result;
        }
        public void mostrar() {
            Console.WriteLine($"{nombre}: {edad} años, {sexo}, {peso}kg, {altura}m. DNI: {DNI}");
        }

        private void GenerarDNI()
        {
            Int32 dni = rnd.Next(10000000, 99999999);

            string dnis = Convert.ToString(dni).Insert(2, "."); dnis = dnis.Insert(6, ".");
            this.DNI = dnis;

            int sexo = rnd.Next(1, 3);

            if (sexo == 1)
            {
                this.sexo = 'M';
            }
            else {
                this.sexo = 'H';
            }
        }

        private void ComprobarSexo(char sexo)
        {
            if (!(sexos.Contains(sexo)))
            {
                this.sexo = 'H';
            }
        }

        public string Nombre{
            set { this.nombre = value; }
        }
        public int Edad
        {
            set { this.edad = value; }
        }
        public char Sexo
        {
            set { this.sexo = value; }
        }
        public double Peso
        {
            set { this.peso = value; }
        }
        public double Altura
        {
            set { this.altura = value; }
        }
    }

    internal class Program
    {
        class Ejecutable {
            static void Main(string[] args)
            {
                List<Int32> dniusados = new List<Int32>();

                Console.WriteLine("Ingrese nombre: ");
                string nombreN = Console.ReadLine();

                Console.WriteLine("Ingrese edad: ");
                int edadN = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Ingrese sexo: 1. hombre        2. mujer");
                ConsoleKeyInfo key = Console.ReadKey(true);
                char sexoN = '0';

                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine("Asignado hombre.");
                    sexoN = 'H';
                }
                else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("Asignado mujer.");
                    sexoN = 'M';
                }
                else
                {
                    Console.WriteLine("Sexo inválido, se asignará hombre.");
                    sexoN = 'I';
                }

                Console.WriteLine("Ingrese peso: ");
                double pesoN = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese altura: ");
                double alturaN = Convert.ToDouble(Console.ReadLine());


                List<Persona> personas = new List<Persona>();
                personas.Add(new Persona(nombreN, edadN, sexoN, pesoN, alturaN));
                personas.Add(new Persona(nombreN, edadN, sexoN));
                personas.Add(new Persona());

                personas[2].Nombre = "pepe";
                personas[2].Edad = 24;
                personas[2].Sexo = 'M';
                personas[2].Peso = 62.52;
                personas[2].Altura = 1.87;

                Console.Clear();
                foreach (Persona per in personas) { per.mostrar(); }

                for (int i = 0; i < personas.Count; i++)
                {
                    int IMC = personas[i].calcularIMC();

                    if (IMC == -1)
                    {
                        Console.WriteLine($"La persona n°{i + 1} está por debajo del peso promedio");
                    }
                    if (IMC == 0)
                    {
                        Console.WriteLine($"La persona n°{i + 1} tiene el peso ideal");
                    }
                    if (IMC == 1)
                    {
                        Console.WriteLine($"La persona n°{i + 1} tiene sobrepeso");
                    }
                }

                Console.ReadKey();

            }
        }
    }
}
