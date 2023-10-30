using chess_2.Objetos;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2.Managers
{
    internal class GameManager
    {
        private readonly Prota protagonista;

        public GameManager() {
            protagonista = new(Globals.Content.Load<Texture2D>("img/chess/W_pawn"), new(Globals.WindowSize.X / 2, Globals.WindowSize.Y - Globals.Content.Load<Texture2D>("img/chess/W_pawn").Height - Globals.Content.Load<Texture2D>("img/scenes/PisoPiedra").Height));
        }

        public void Update()
        {
            protagonista.Update();
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin();

            protagonista.Draw();

            Globals.SpriteBatch.End();
        }
    }
}
