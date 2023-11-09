using chess_2.Objetos;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_2.Escenas;

namespace chess_2.Managers
{
    internal class GameManager
    {
        private readonly FondoManager _Wallpapermanager;
        public SceneManager _SceneManager { get; }

        private readonly Prota _protagonista;
        
        public GameManager() {
            _protagonista = new(Globals.Content.Load<Texture2D>("img/chess/W_pawn"), new(Globals.WindowSize.X / 2, Globals.WindowSize.Y - Globals.Content.Load<Texture2D>("img/chess/W_pawn").Height - Globals.Content.Load<Texture2D>("img/scenes/elementos/PisoPiedra").Height));            
            _Wallpapermanager = new();
            _SceneManager = new();
            _SceneManager.LoadScene(new TestDebug());
        }

        public void Update()
        {
            CrearMatriz();
            _protagonista.Update();
            _Wallpapermanager.Update();
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin(transformMatrix: Globals.viewMatrix);

            _Wallpapermanager.Draw();
            _SceneManager.BackgroundDraw();
           
            _SceneManager.Draw();
            _protagonista.Draw();
            if (Globals.Debug) {
                Debug();
            }

            Globals.SpriteBatch.End();
        }

        public void Debug() {
            Texture2D pixel = new Texture2D(Globals.GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });

            foreach (Rectangle rect in Globals.SceneRectangles) {
                Globals.SpriteBatch.Draw(pixel, rect, Color.White * 0.5f);
            }

            Globals.SpriteBatch.Draw(pixel, new Rectangle((int)_protagonista.Position.X, (int)_protagonista.Position.Y, _protagonista.Texture.Width, _protagonista.Texture.Height), Color.White * 0.5f);
        }

        public void CrearMatriz() {
            Globals.viewMatrix = Matrix.CreateTranslation(new Vector3(-_protagonista.Position.X + Globals.WindowSize.X / 2, -_protagonista.Position.Y + (Globals.WindowSize.Y / 2)/* + _protagonista.Position.Y / 4*/, 0));
        }
    }
}
