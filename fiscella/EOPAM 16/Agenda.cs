using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_16
{
    internal class Agenda
    {
        List<Contacto> contactos = new List<Contacto>();
        int limite;

        public Agenda(int limite = 10)
        {
            this.limite = limite;
        }

        public string añadirContacto(Contacto c) {
            if (contactos.Count() < limite) {
                if (!contactos.Exists(con => con.Nombre == c.Nombre))
                {
                    contactos.Add(c);
                    return "Contacto añadido";
                }
                return "Contacto ya existente";
            }
            return "Agenda llena";
        }

        public string existeContacto(Contacto c) {
            if (contactos.Exists(con => con.Nombre == c.Nombre && con.Telefono == c.Telefono)) {
                return $"Contacto Existe: {contactos.Find(con => con.Nombre == c.Nombre).Mostrar()}";
            }
            return "Contacto no existente";
        }

        public string[] listarContactos() {
            string[] strings = new string[contactos.Count()];
            string[] noHay = { "no hay contactos" };

            for(int i = 0; i < contactos.Count(); i++) {
                strings[i] = contactos[i].Mostrar(); 
            }

            return strings.Length == 0 ? noHay : strings;
        }

        public Contacto buscarContacto(string nombre) {
            return contactos.Find(con => con.Nombre == nombre);
        }

        public string eliminarContacto(Contacto c) {
            if (contactos.RemoveAll(con => con.Nombre == c.Nombre && con.Telefono == c.Telefono) == 1) {
                return "Contacto eliminado";
            }
            return "Contacto no encontrado";
        }

        public string agendaLlena() {
            return contactos.Count() == limite ? "Agenda llena." : "La agenda aun tiene espacios disponibles"; // $"Agenda con {limite - contactos.Count()} espacios disponibles"; lo hice sin leer el siguiente punto, un adelantado a mi tiempo
        }

        public string huecosLibres() { 
            return contactos.Count() == limite ? "Agenda sin espacios disponibles" : $"Agenda con {limite - contactos.Count()} espacios disponibles"; // es lo mismo que la otra funcion, tranquilamente podria usar esta para comprobar si la agenda está llena . _.
        }
    }
}
