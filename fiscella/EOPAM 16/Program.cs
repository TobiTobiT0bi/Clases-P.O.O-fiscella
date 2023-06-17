using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        static void Main(string[] args)
        {
        }
    }
}
