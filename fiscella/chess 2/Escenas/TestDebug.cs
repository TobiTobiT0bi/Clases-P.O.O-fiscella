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
    public class TestDebug : Scene{

        private readonly Superficie _piso;
        private readonly Superficie _paredDerecha;
        private readonly Superficie _paredIzquierda;
        public new string fondo = "panqueque";

        public TestDebug() : base() {
            _piso = new(Globals.Content.Load<Texture2D>("img/scenes/elementos/PisoPiedra"), new(0, Globals.WindowSize.Y - Globals.Content.Load<Texture2D>("img/scenes/elementos/PisoMadera").Height));
            _paredDerecha = new(new Texture2D(Globals.GraphicsDevice, 15, Globals.WindowSize.Y), new(Globals.WindowSize.X, 0));
            _paredIzquierda = new(new Texture2D(Globals.GraphicsDevice, 15, Globals.WindowSize.Y), new(-15, 0));
            Globals.SceneRectangles = GetRectangles();
            LoadFondo();
        }

        public override List<Rectangle> GetRectangles() {
            List<Rectangle> result = new List<Rectangle> { _piso.Rectangle, _paredDerecha.Rectangle, _paredIzquierda.Rectangle };

            return result;
        }

        public override void LoadFondo()
        {
            Globals.Scene = fondo;
        }

        public override void Draw() { 
            _piso.Draw();
        }
    }
}
