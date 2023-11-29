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
    internal class Parque : Scene
    {
        private readonly Superficie _piso;
        private readonly Superficie _paredDerecha;
        private readonly Superficie _paredIzquierda;
        private readonly Sprite _chessboard;
        public new string fondo = "parque";

        private readonly Superficie _plataformaDerecha;
        private readonly Superficie _plataformaIzquierda;
        private readonly Superficie _plataformaMedia;

        public Parque() : base()
        {
            _piso = new(Globals.Content.Load<Texture2D>("img/scenes/elementos/PisoMadera"), new(0, Globals.WindowSize.Y - Globals.Content.Load<Texture2D>("img/scenes/elementos/PisoMadera").Height));
            _chessboard = new(Globals.Content.Load<Texture2D>("img/scenes/elementos/chessboard"), new(Globals.WindowSize.X / 2 - Globals.Content.Load<Texture2D>("img/scenes/elementos/chessboard").Width / 2, Globals.WindowSize.Y - Globals.Content.Load<Texture2D>("img/scenes/elementos/PisoMadera").Height - Globals.Content.Load<Texture2D>("img/scenes/elementos/chessboard").Height));
            _paredDerecha = new(new Texture2D(Globals.GraphicsDevice, 15, Globals.WindowSize.Y), new(Globals.WindowSize.X, 0));
            _paredIzquierda = new(new Texture2D(Globals.GraphicsDevice, 15, Globals.WindowSize.Y), new(-15, 0));

            _plataformaDerecha = new(Globals.Content.Load<Texture2D>("img/scenes/elementos/plataformaLargaGrass"), new(_chessboard.Position.X + _chessboard.Texture.Width - Globals.Content.Load<Texture2D>("img/scenes/elementos/plataformaLargaGrass").Width, (Globals.WindowSize.Y / 2) + 15));
            _plataformaIzquierda = new(Globals.Content.Load<Texture2D>("img/scenes/elementos/plataformaLargaGrass"), new(_chessboard.Position.X, (Globals.WindowSize.Y / 2) + 15));
            _plataformaMedia = new(Globals.Content.Load<Texture2D>("img/scenes/elementos/plataformaChicaGrass"), new(Globals.WindowSize.X / 2 - Globals.Content.Load<Texture2D>("img/scenes/elementos/plataformaChicaGrass").Width / 2, 150));

            //Globals.SceneRectangles = GetRectangles();
            LoadFondo();
        }

        public override List<Rectangle> GetRectangles()
        {
            List<Rectangle> result = new List<Rectangle> { 
                _piso.Rectangle, 
                _paredDerecha.Rectangle, 
                _paredIzquierda.Rectangle,
                _plataformaDerecha.Rectangle,
                _plataformaIzquierda.Rectangle,
                _plataformaMedia.Rectangle,
            };

            return result;
        }

        public override void LoadFondo()
        {
            Globals.Scene = fondo;
        }

        public override void Draw()
        {
            _piso.Draw();
            _plataformaIzquierda.Draw();
            _plataformaDerecha.Draw();
            _plataformaMedia.Draw();
        }

        public override void BackgroundDraw()
        {
            _chessboard.Draw();
        }
    }
}
