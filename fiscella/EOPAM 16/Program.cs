using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using menuTools;

/* 
Nos piden realizar una agenda telefónica de contactos.
Un contacto está definido por un nombre y un teléfono (No es necesario de validar). Un contacto es igual a otro cuando sus nombres son iguales.
Una agenda de contactos está formada por un conjunto de contactos (Piensa en qué tipo puede ser)
Se podrá crear de dos formas, indicando nosotros el tamaño o con un tamaño por defecto (10)
Los métodos de la agenda serán los siguientes:
aniadirContacto(Contacto c): Añade un contacto a la agenda, sino se pueden meter más a la agenda se indicará por pantalla. No se pueden meter contactos que existan, es decir, no podemos duplicar nombres, aunque tengan distinto teléfono.
existeContacto(Conctacto c): indica si el contacto pasado existe o no.
listarContactos(): Lista toda la agenda
buscaContacto(String nombre): busca un contacto por su nombre y muestra su teléfono.
eliminarContacto(Contacto c): elimina el contacto de la agenda, indica si se ha eliminado o no por pantalla
agendaLlena(): indica si la agenda está llena.
huecosLibres(): indica cuántos contactos más podemos meter.
Crea un menú con opciones por consola para probar todas estas funcionalidades.

 */
namespace EOPAM_16
{
    internal class Program
    {
        static string[] recolectarContacto(string nombreTemp, string telefonoTemp, bool tele = true) {

            Menu.resetConsole(true);
            Console.Write("Ingrese el nombre del contacto: ");
            Console.ForegroundColor = ConsoleColor.Green;
            nombreTemp = Console.ReadLine();
            Menu.resetConsole(30, 9);

            if (tele) {
                Console.Write("Ingrese el número de telefono: ");
                Console.ForegroundColor = ConsoleColor.Green;
                telefonoTemp = Console.ReadLine();
                Menu.resetConsole(30, 10);
            }

            string[] devolver = { nombreTemp, telefonoTemp };

            return devolver;
        }

        static void Main(string[] args)
        {
            string[] menu = { 
                "1. Añadir un contacto",
                "2. Comprobar si un contacto existe",
                "3. Listar todos los contactos",
                "4. Buscar un contacto en especifico",
                "5. Eliminar un contacto",
                "6. Comprobar si la agenda está llena",
                "7. Comprobar cuantos huecos libres tiene la agenda",
                "8. salir"
            };

            Console.WriteLine("Ingrese el tamaño de la agenda (Enter para 10)");
            string leer = Console.ReadLine();

            int limite = leer == "" ? 0 : Convert.ToInt32(leer);

            Agenda agenda = limite == 0 ? new Agenda() : new Agenda(limite);
            Console.Clear();

            string nombreTemp = "" ;
            string telefonoTemp = "";
            string[] datos = new string[2];
            bool salir = false;

            Menu.Crear(menu);

            while (true) {
                int pos = Menu.movilidad(menu);

                switch (pos)
                {
                    case 0:
                        datos = recolectarContacto(nombreTemp, telefonoTemp);

                        Console.Write(agenda.añadirContacto(new Contacto(datos[0], datos[1])));
                        Console.ReadKey();

                        Menu.resetConsole(true);
                        Menu.Crear(menu);
                        break;

                    case 1:
                        datos = recolectarContacto(nombreTemp, telefonoTemp);

                        Menu.resetConsole(Console.CursorLeft, Console.CursorTop + 1);
                        Console.Write(agenda.existeContacto(new Contacto(datos[0], datos[1])));
                        Console.ReadKey();

                        Menu.resetConsole(true);
                        Menu.Crear(menu);
                        break;

                    case 2:
                        Menu.resetConsole(0, 0, true);
                        Console.WriteLine(string.Join("\n", agenda.listarContactos()));
                        Console.ReadKey();
                        Menu.resetConsole(true);
                        Menu.Crear(menu);
                        break;

                    case 3:
                        datos = recolectarContacto(nombreTemp, " ", false);

                        Console.Write(agenda.buscarContacto(datos[0]).Mostrar());
                        Console.ReadKey();

                        Menu.resetConsole(true);
                        Menu.Crear(menu);
                        break;

                    case 4:
                        datos = recolectarContacto(nombreTemp, telefonoTemp);

                        Console.Write(agenda.eliminarContacto(new Contacto(datos[0], datos[1])));
                        Console.ReadKey();

                        Menu.resetConsole(true);
                        Menu.Crear(menu);
                        break;

                    case 5:
                        Menu.resetConsole(true);
                        Console.Write(agenda.agendaLlena());
                        Console.ReadKey();

                        Menu.resetConsole(true);
                        Menu.Crear(menu);
                        break;

                    case 6:
                        Menu.resetConsole(true);
                        Console.Write(agenda.huecosLibres());
                        Console.ReadKey();

                        Menu.resetConsole(true);
                        Menu.Crear(menu);
                        break;

                    case 7:
                        salir = true;
                        break;
                }

                if (salir) break;
            }
        }
    }
}
