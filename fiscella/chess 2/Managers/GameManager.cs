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

        private readonly Prota _protagonista;
        private readonly TestDebug _debugScene;
        
        public GameManager() {
            _protagonista = new(Globals.Content.Load<Texture2D>("img/chess/W_pawn"), new(Globals.WindowSize.X / 2, Globals.WindowSize.Y - Globals.Content.Load<Texture2D>("img/chess/W_pawn").Height - Globals.Content.Load<Texture2D>("img/scenes/elementos/PisoPiedra").Height));            
            _Wallpapermanager = new();
            _debugScene = new();
        }

        public void Update()
        {
            _protagonista.Update();
            _Wallpapermanager.Update();
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin();

            _Wallpapermanager.Draw();
            _protagonista.Draw();
            _debugScene.Draw();

            Globals.SpriteBatch.End();
        }
    }
}
