using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace editor_imagenes
{
    public partial class Form1 : Form
    {
        HistorialImagenes HistorialImagenes = new HistorialImagenes();
        string lastFile;
        string activeFile;
        int position = 0;


        public Form1()
        {
            InitializeComponent();
            archivos.Visible = false;
            rotarIzquierda.Visible = false;
            rotarDerecha.Visible = false;
            espejo.Visible = false;

            foreach (Control control in this.Controls) {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(Form1_PreviewKeyDown);
            }
            
        }

        private void selectImages_Click(object sender, EventArgs e)
        {
            archivo.Filter = "Imagenes JPG|*.jpg|Archivos PDF|*.pdf|Imagenes PNG|*.png";

            if (archivo.ShowDialog() == DialogResult.OK) {
                try {
                    Imagen.Image = Image.FromFile(archivo.FileName);

                    HistorialImagenes.añadir(archivo);
                    lastFile = archivo.FileName;
                    activeFile = archivo.FileName;
                    archivos.Items.Add($"{archivo.SafeFileName}");
                    position = archivos.Items.Count - 1;

                    rotarDerecha.Visible = true;
                    rotarIzquierda.Visible = true;
                    espejo.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void salir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Salir de la aplicacion?", "SALIR", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                Application.Exit(); 
            }
        }

        private void historial_Click(object sender, EventArgs e)
        {
            archivos.Visible = !archivos.Visible;
        }

        private void archivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (archivos.SelectedItem != null) {
                    Imagen.Image = Image.FromFile(HistorialImagenes.convertSafeToFile(archivos.SelectedItem.ToString()));
                    activeFile = HistorialImagenes.convertSafeToFile(archivos.SelectedItem.ToString());
                    lastFile = archivo.FileName;
                    position = HistorialImagenes.getIndex(HistorialImagenes.convertSafeToFile(archivos.SelectedItem.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rotarDerecha_Click(object sender, EventArgs e)
        {
            Image i = Imagen.Image;

            i.RotateFlip(RotateFlipType.Rotate270FlipXY);

            Imagen.Image = i;

            // ordenen las cartas ustedes ahora, imbeciles
        }

        private void rotarIzquierda_Click(object sender, EventArgs e)
        {
            Image i = Imagen.Image;

            i.RotateFlip(RotateFlipType.Rotate90FlipXY);

            Imagen.Image = i;
        }

        private void espejo_Click(object sender, EventArgs e)
        {
            Image i = Imagen.Image;

            i.RotateFlip(RotateFlipType.Rotate180FlipY);

            Imagen.Image = i;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == (char)Keys.Right && position + 1 < archivos.Items.Count)
                {
                    Imagen.Image = Image.FromFile(HistorialImagenes.convertIndexToFile(HistorialImagenes.getIndex(activeFile) + 1));
                    activeFile = HistorialImagenes.getSafeName(HistorialImagenes.getIndex(activeFile) + 1);
                    position = HistorialImagenes.getIndex(activeFile) + 1;

                }
                if (e.KeyValue == (char)Keys.Left && position > 0)
                {
                    Imagen.Image = Image.FromFile(HistorialImagenes.convertIndexToFile(HistorialImagenes.getIndex(activeFile) - 1));
                    activeFile = HistorialImagenes.getSafeName(HistorialImagenes.getIndex(activeFile) - 1);
                    position = HistorialImagenes.getIndex(activeFile) - 1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) { 
                e.IsInputKey = true;
            }
        }
    }
}
