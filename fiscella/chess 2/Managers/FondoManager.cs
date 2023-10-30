using chess_2.Objetos;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace chess_2.Managers
{
    internal class FondoManager
    {
        private Sprite Wallpaper;
        private string escenaActiva = string.Empty;

        public FondoManager() {
            Wallpaper = new(new(0, 0));
        }

        public void ChangeFondo(string ruta) {
            Wallpaper = new Sprite(Globals.Content.Load<Texture2D>(ruta), new(0, 0));
        }

        public void Update() {
            if (escenaActiva != Globals.Scene) {
                ChangeFondo($"img/scenes/{Globals.Scene}");
            }           
        }

        public void Draw() {
            Wallpaper.Draw();
        }
    }
}
