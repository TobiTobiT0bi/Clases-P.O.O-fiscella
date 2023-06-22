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

namespace Ejercicios_con_formularios_1
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int minY = 131; 

        public Form1()
        {
            InitializeComponent();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && Regex.IsMatch(textBox1.Text, "[a-zA-Z01]")) {
                button1.Location = new Point(12, 250);
                listBox1.Items.Insert(0, textBox1.Text);
                textBox1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && !Regex.IsMatch(textBox1.Text, "[a-zA-Z0-9]"))
            {
                button1.Location = new System.Drawing.Point(rnd.Next(250, 500), rnd.Next(minY, 450));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Height = 250;
            listBox1.Width = 10000;
            minY = 260;
            textBox1.Location = new System.Drawing.Point(12, 260);
            button1.Location = new System.Drawing.Point(rnd.Next(250, 500), rnd.Next(minY, 430));
            button2.Visible = false;
        }
    }
}
