using chess_2.Objetos;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2.Escenas
{
    internal class TestDebug {

        private readonly Superficie _piso;

        public TestDebug() {
            _piso = new(Globals.Content.Load<Texture2D>("img/scenes/elementos/PisoPiedra"), new(0, Globals.WindowSize.Y - Globals.Content.Load<Texture2D>("img/scenes/elementos/PisoPiedra").Height));
            Globals.Scene = "taverna";
        }



        public void Draw() { 
            _piso.Draw();
        }
    }
}
