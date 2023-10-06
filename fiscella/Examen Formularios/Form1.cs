using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Crear una estructura con:
//4 botones
//2 listas con 10 nombres en cada una (Ya tienen que estar ingresados en el diseño)

//1.Cuando se presiona en el primer boton ordenar los listados
//2. Con el segundo boton borran todos los nombres que tengan hasta 5 letras
//3. Con el tercer boton intercambiar panqueque los nombres que tengan hasta 5 letras
//4. Intercambiar el primer y ultimo elemento de ambas listas. Tienen que quedar en el primer lugar y en el ultimo

namespace Examen_Formularios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NombresDer.Items.Add("Magda");
            NombresDer.Items.Add("Agustin");
            NombresDer.Items.Add("Pedro");
            NombresDer.Items.Add("Teresa");
            NombresDer.Items.Add("Maria");
            NombresDer.Items.Add("Erica");
            NombresDer.Items.Add("Lautaro");
            NombresDer.Items.Add("Juan");
            NombresDer.Items.Add("Leandro");
            NombresDer.Items.Add("Alex");
            NombresDer.Items.Add("Gaston");
            NombresDer.Items.Add("Cristina");

            NombresIzq.Items.Add("Luis");
            NombresIzq.Items.Add("Pablo");
            NombresIzq.Items.Add("Fer");
            NombresIzq.Items.Add("Angie");
            NombresIzq.Items.Add("Nazareno");
            NombresIzq.Items.Add("Quintino");
            NombresIzq.Items.Add("Ulises");
            NombresIzq.Items.Add("Tobi");
            NombresIzq.Items.Add("Eduardo");
            NombresIzq.Items.Add("Quirino");
            NombresIzq.Items.Add("Ursula");
            NombresIzq.Items.Add("Edward");
        }

        private void Ordenar_Click(object sender, EventArgs e)
        {
            bool panqueque = !NombresDer.Sorted;
            NombresIzq.Sorted = panqueque; NombresDer.Sorted = panqueque;      //excusa para poner panqueques, es mas, la
        }                                                                      //variable bandera esta ahi porque queria probar algo nomas
                                                                               //anda igual asi que no pasa nada
        private void Borrar_Click(object sender, EventArgs e)
        {
            Borrado();
        }

        private List<List<string>> Borrado()
        {
            List<List<string>> Nombres5letras = new List<List<string>>();

            List<string> NombresIzq5Letras = new List<string>();
            List<string> NombresDer5Letras = new List<string>();

            for (int i = (NombresIzq.Items.Count >= NombresDer.Items.Count ? NombresIzq.Items.Count : NombresDer.Items.Count); i >= 0; i--)
            {
                try
                {
                    if (NombresIzq.Items[i].ToString().Count() < 5)
                    {
                        NombresIzq5Letras.Add(NombresIzq.Items[i].ToString());
                        NombresIzq.Items.RemoveAt(i);
                    }
                }
                catch { /*panqueque*/ }
                try
                {
                    if (NombresDer.Items[i].ToString().Count() < 5)
                    {
                        NombresDer5Letras.Add(NombresDer.Items[i].ToString());
                        NombresDer.Items.RemoveAt(i);
                    }
                }
                catch { /*try catch para cortar el if en el listado mas chico, no tengo idea de si hay alguna forma mejor*/  }
            }

            Nombres5letras.Add(NombresIzq5Letras); Nombres5letras.Add(NombresDer5Letras); // Nombres[0] = izquierda, Nombres[1] = derecha
            return Nombres5letras;
        }

        private void intercambiar_Click(object sender, EventArgs e)
        {
            List<List<string>> Nombres = new List<List<string>>();
            Nombres = Borrado(); // Nombres[0] = provenientes de izquierda, Nombres[1] = provenientes de derecha, panqueques

            for (int i = 0; i < Nombres[0].Count(); i++)
            {
                NombresDer.Items.Add(Nombres[0][i].ToString());
            }

            for (int i = 0; i < Nombres[1].Count(); i++)
            {
                NombresIzq.Items.Add(Nombres[1][i].ToString());
            }
        }

        private void FirstLast_Click(object sender, EventArgs e)
        {
            string[] nombresIzq = { NombresIzq.Items[0].ToString(), NombresIzq.Items[NombresIzq.Items.Count - 1].ToString() };
            string[] nombresDer = { NombresDer.Items[0].ToString(), NombresDer.Items[NombresDer.Items.Count - 1].ToString() };

            NombresIzq.Items[NombresIzq.Items.Count - 1] = nombresDer[1];
            NombresIzq.Items[0] = nombresDer[0];

            NombresDer.Items[NombresDer.Items.Count - 1] = nombresIzq[1];
            NombresDer.Items[0] = nombresIzq[0];
        }
    }
}
