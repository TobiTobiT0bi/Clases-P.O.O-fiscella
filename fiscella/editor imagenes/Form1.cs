using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace editor_imagenes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            archivo.Filter = "Imagenes JPG|*.jpg|Archivos PDF|*.pdf|Imagenes PNG|*.png";

            if (archivo.ShowDialog() == DialogResult.OK) {
                try {
                    Imagen.Image = Image.FromFile(archivo.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
