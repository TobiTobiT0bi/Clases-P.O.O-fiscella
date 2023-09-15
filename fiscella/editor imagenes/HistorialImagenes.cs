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
    internal class HistorialImagenes
    {
        List<string> safeName = new List<string>();
        List<string> fileName = new List<string>();

        public HistorialImagenes() { }

        public void añadir(OpenFileDialog file) {
            safeName.Add(file.SafeFileName);
            fileName.Add(file.FileName);
        }

        public string getSafeName(int index) {
            return safeName[index];
        }

        public string getFileName(int index) {  
            return fileName[index]; 
        }

        public int getIndex(string namefile) {
            return fileName.FindIndex(file => file == namefile);
        }

        public string convertSafeToFile(string Safefile) {
            return fileName[safeName.FindIndex(file => file == Safefile)];
        }

        public string convertIndexToFile(int index)
        {
            return fileName[index];
        }
    }
}
