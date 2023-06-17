using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_15
{
    internal class Almacen
    {
        List<Bebida>[,] estanterias;

        public Almacen(int cantEstantes) {
            estanterias = new List<Bebida>[cantEstantes, 1];
            for (int i = 0; i < cantEstantes; i++) {
                estanterias[i, 0] = new List<Bebida>();
            }
        }

        public float precioTotal() {
            float total = 0;

            foreach (List<Bebida> estante in estanterias) {
                foreach (Bebida b in estante)
                {
                    total += b.Precio;
                }
            }

            return total;
        }

        public string precioMarca(string marca) {
            float total = 0;

            foreach (List<Bebida> estante in estanterias) {
                foreach (Bebida b in estante) {
                    total += b.Marca.ToLower() == marca.ToLower() ? b.Precio : 0;
                }
            }

            return total == 0 ? "Marca no encontrada" : $"Precio total de esta marca: {total}" ;
        }

        public string precioEstante(int idEstante)
        {
            List<Bebida> estante = new List<Bebida>();

            try
            {
                estante = estanterias[idEstante, 0];
            }
            catch {
                return "Estanteria no encontrada";
            }

            float total = 0;

            foreach(Bebida b in estante)
            {
                total += b.Precio;
            }

            return total == 0 ? "Estanteria vacia" : $"Precio total de esta estanteria: {total}";
        }

        public string agregarProducto(Bebida bebi) {
            bool existe = false;

            foreach (List<Bebida> estante in estanterias) {
                if (estante.Exists(b => b.Identificador == bebi.Identificador)) {
                    existe = true;
                }
            }

            foreach(List<Bebida> estante in estanterias) {
                if (existe == false)
                {
                    if (estante.Count() < 20) {
                        estante.Add(bebi);
                        return "Producto agregado";
                    }
                }
                else {
                    return "Identificador de producto ya existente";
                }
            }
            return "Todos las estanterias estan llenas";
        }
        public string eliminarProducto(int produID)
        {
            foreach (List<Bebida> estante in estanterias) {
                for (int i = 0; i < estante.Count(); i++) {
                    if (estante[i].Identificador == produID) { 
                        estante.RemoveAt(i);
                        return "Producto eliminado";
                    }
                }
            }

            return "Producto no encontrado";
        }

        public string mostrarTodo() {
            string principal = "";

            for(int i = 0; i < estanterias.GetLength(0); i++) {
                principal += $"\nESTANTERIA {i}\n\n";
                foreach (Bebida bebi in estanterias[i, 0]) { 
                    principal += $"{bebi.Mostrar()}\n";
                }
                principal += "\n";
            }

            return principal;
        }

    }
}
