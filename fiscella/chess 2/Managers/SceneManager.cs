using chess_2.Escenas;
using chess_2.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2.Managers
{
    internal class SceneManager
    {
        Scene escena;

        public SceneManager() { }

        public void LoadScene(Scene escenaNueva) {
            escena = escenaNueva;
        }

        public void Draw() { 
            escena.Draw();
        }

        public void BackgroundDraw() { 
            escena.BackgroundDraw();
        }
    }
}
