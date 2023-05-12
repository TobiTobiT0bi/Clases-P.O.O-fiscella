using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

/* 
3) Haz una clase llamada Password que siga las siguientes condiciones:
Que tenga los atributos longitud y contraseña . Por defecto, la longitud sera de 8.
Los constructores serán los siguiente:
Un constructor por defecto.
Un constructor con la longitud que nosotros le pasemos. Generará una contraseña aleatoria con esa longitud.
Los métodos que implementa serán:
esFuerte(): devuelve un booleano si es fuerte o no, para que sea fuerte debe tener mas de 2 mayúsculas, mas de 1 minúscula y mas de 5 números.
generarPassword():  genera la contraseña del objeto con la longitud que tenga.
Método get para contraseña y longitud.
Método set para longitud.
Ahora, crea una clase clase ejecutable:
Crea un array de Passwords con el tamaño que tu le indiques por teclado.
Crea un bucle que cree un objeto para cada posición del array.
Indica también por teclado la longitud de los Passwords (antes de bucle).
Crea otro array de booleanos donde se almacene si el password del array de Password es o no fuerte (usa el bucle anterior).
Al final, muestra la contraseña y si es o no fuerte (usa el bucle anterior). Usa este simple formato:
contraseña1 valor_booleano1
contraseña2 valor_bololeano2
*/

namespace EOPAM_3
{
    public class Password
    {
        const int longituDefecto = 8;

        public int longitud = longituDefecto;
        public string contraseña = "";


        public Password() { generarContraseña(); }

        public Password(int longitud)
        {
            this.longitud = longitud;

            generarContraseña();
        }

        public bool esFuerte()
        {
            int numeros = 0;
            int Upper = 0;
            int Lower = 0;

            for (int i = 0; i < longitud; i++) {
                if (char.IsUpper(contraseña, i))
                {
                    Upper++;
                }
                else if (char.IsLower(contraseña, i))
                {
                    Lower++;
                }
                else if (char.IsNumber(contraseña, i)) {
                    numeros++;
                }
            }

            if (Upper > 2 && Lower > 1 && numeros > 5)
            {
                return true;
            }
            else {
                return false;
            }
        }

        private void generarContraseña()
        {
            char[] Uppers = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] Lowers = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            Random rnd = new Random();
            List<char> chars = new List<char>();

            for(int i = 0; i <= longitud; i++){
                int panqueques = rnd.Next(1, 4);
                int debug = 0;  

                switch (panqueques) {
                    case 1:
                        debug = rnd.Next(0, Lowers.Length);
                        chars.Add(Lowers[debug]);
                        break;
                    case 2:
                        debug = rnd.Next(0, Uppers.Length);
                        chars.Add(Uppers[debug]);
                        break;
                    case 3:
                        chars.Add(Convert.ToChar(Convert.ToString(rnd.Next(1, 10))));
                        break;
                }              
            }
            
            this.contraseña = new string(chars.ToArray());
        }
        public void mostrar()
        {
            //Console.WriteLine($"{nombre}: {edad} años, {sexo}, {peso}kg, {altura}m. DNI: {DNI}");
        }

        public int Longitud
        {
            get { return this.longitud; } set { this.longitud = value; }
        }
        public string Contraseña
        {
            get { return this.contraseña; }
        }
    }

    internal class Program
    {
        class Ejectubale {
            static void Main(string[] args)
            {

                Console.WriteLine("¿Cuantas contraseñas querés crear?: ");
                Password[] passes = new Password[Convert.ToInt16(Console.ReadLine())];
                bool[] fuertes = new bool[passes.Length]; 

                for (int i = 0; i < passes.Length; i++) {
                    Console.WriteLine($"Ingrese tamaño de la contraseña n°{i + 1}: ");
                    int longi = Convert.ToInt16(Console.ReadLine());

                    passes[i] = new Password(longi);
                    fuertes[i] = passes[i].esFuerte();

                    Console.WriteLine($"contraseña {i + 1}: {passes[i].Contraseña}, {fuertes[i]}");
                }
                Console.Clear();
                for (int i = 0; i < fuertes.Length;i++) {
                    Console.WriteLine($"contraseña {i + 1}: {passes[i].Contraseña}, {fuertes[i]}");
                }
                Console.ReadKey();
            }
        }      
    }
}
