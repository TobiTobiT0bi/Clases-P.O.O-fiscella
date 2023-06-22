using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            boxLeft.Items.Insert(0, textLeft.Text);
        }

        private void agregaRight_Click(object sender, EventArgs e)
        {
            boxRight.Items.Insert(0, textRight.Text);
        }

        private void allToLeft_Click(object sender, EventArgs e)
        {
            for(int i = boxRight.Items.Count; i > 0; i--)
            {
                boxLeft.Items.Insert(0, boxRight.Items[i - 1]);
            }
        }

        private void allToRight_Click(object sender, EventArgs e)
        {
            for (int i = boxLeft.Items.Count; i > 0; i--)
            {
                boxRight.Items.Insert(0, boxLeft.Items[i - 1]);
            }
        }

        private void toLeft_Click(object sender, EventArgs e)
        {
            for (int i = boxRight.SelectedItems.Count; i > 0; i--)
            {
                boxLeft.Items.Insert(0, boxRight.SelectedItems[i - 1]);
            }
        }

        private void toRight_Click(object sender, EventArgs e)
        {
            for (int i = boxLeft.SelectedItems.Count; i > 0; i--)
            {
                boxRight.Items.Insert(0, boxLeft.SelectedItems[i - 1]);
            }
        }
    }
}
