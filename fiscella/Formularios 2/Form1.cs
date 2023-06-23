using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Formularios_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void agregaLeft_Click(object sender, EventArgs e)
        {
            if (textLeft.Text != "" && Regex.IsMatch(textLeft.Text, "[a-zA-Z0-9]"))
            {
                boxLeft.Items.Insert(0, textLeft.Text);
                textLeft.Clear();
            }
        }

        private void agregaRight_Click(object sender, EventArgs e)
        {
            if (textRight.Text != "" && Regex.IsMatch(textRight.Text, "[a-zA-Z0-9]"))
            {
                boxRight.Items.Insert(0, textRight.Text);
                textRight.Clear();
            }
        }

        private void allToLeft_Click(object sender, EventArgs e)
        {
            for(int i = boxRight.Items.Count; i > 0; i--)
            {
                boxLeft.Items.Insert(0, boxRight.Items[i - 1]);
                boxRight.Items.Remove(boxRight.Items[i - 1]);
            }
        }

        private void allToRight_Click(object sender, EventArgs e)
        {
            for (int i = boxLeft.Items.Count; i > 0; i--)
            {
                boxRight.Items.Insert(0, boxLeft.Items[i - 1]);
                boxLeft.Items.Remove(boxLeft.Items[i - 1]);
            }
        }

        private void toLeft_Click(object sender, EventArgs e)
        {
            for (int i = boxRight.SelectedItems.Count; i > 0; i--)
            {
                boxLeft.Items.Insert(0, boxRight.SelectedItems[i - 1]);
                boxRight.Items.Remove(boxRight.SelectedItems[i - 1]);              
            }
        }

        private void toRight_Click(object sender, EventArgs e)
        {
            for (int i = boxLeft.SelectedItems.Count; i > 0; i--)
            {
                boxRight.Items.Insert(0, boxLeft.SelectedItems[i - 1]);
                boxLeft.Items.Remove(boxLeft.SelectedItems[i - 1]);
            }
        }

        private void textLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) {
                agregaLeft_Click(sender, e);
            }
        }

        private void textRight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                agregaRight_Click(sender, e);
            }
        }

        private void trashLeft_Click(object sender, EventArgs e)
        {
            if (boxLeft.SelectedItems.Count > 0) {
                boxLeft.Items.RemoveAt(boxLeft.SelectedIndex);
            }
            else {
                DialogResult borrar = MessageBox.Show("¿Borrar todos los elementos de la izquierda?", "Borrar izquierda", MessageBoxButtons.YesNo);
                if (borrar == DialogResult.Yes)
                {
                    for (int i = boxLeft.Items.Count; i > 0; i--)
                    {
                        boxLeft.Items.Remove(boxLeft.Items[i - 1]);
                    }
                }
            }       
        }

        private void trashRight_Click(object sender, EventArgs e)      
        {
            if (boxRight.SelectedItems.Count > 0) {
                boxRight.Items.RemoveAt(boxRight.SelectedIndex);
            }
            else {
                DialogResult borrar = MessageBox.Show("¿Borrar todos los elementos de la derecha?", "Borrar derecha", MessageBoxButtons.YesNo);
                if (borrar == DialogResult.Yes) {
                    for (int i = boxRight.Items.Count; i > 0; i--)
                    {
                        boxRight.Items.Remove(boxRight.Items[i - 1]);
                    }
                }  
            }         
        }
    }
}
