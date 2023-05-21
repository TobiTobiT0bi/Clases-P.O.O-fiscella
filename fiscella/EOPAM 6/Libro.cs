using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOPAM_6
{
    public class Libro
    {
        private bool ISBN = true;
        private string titulo;
        private string autor;
        private int numeroDePaginas;

        public Libro()
        {

        }
        public Libro(string titulo, string autor, int paginas)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.numeroDePaginas = paginas;
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public int Paginas
        {
            get { return numeroDePaginas; }
            set { numeroDePaginas = value; }
        }

        public bool iSBN
        {
            get { return ISBN; }
            set { ISBN = value; }
        }
    }
}
