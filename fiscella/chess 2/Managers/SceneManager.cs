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
        public TileMap escena;

        public SceneManager() { }

        public void LoadScene(TileMap escenaNueva) {
            escena = escenaNueva;
        }

        public void Update() {
            escena.Update();
        }

        public TileMap GetEscena() {
            return escena;
        }

        public void Draw() { 
            escena.Draw();
        }
    }
}
