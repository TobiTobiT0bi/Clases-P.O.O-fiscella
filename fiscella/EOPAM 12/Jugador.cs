using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_12
{
    internal class Jugador {
        int id;
        string nombre;
        bool vivo = true;

        public Jugador(int id) {
            this.id = id;
            nombre = $"Jugador {id}";
        }

        public bool Disparar(Revolver r) { 
            return r.Disparar();
        }

        public bool Vivo { get { return vivo; } set { vivo = value ; } }
        public string Nombre { get { return nombre; } }
    }
}
