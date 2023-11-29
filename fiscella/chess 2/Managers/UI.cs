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
    internal class UI
    {
        public SpriteFont font;

        public string Vida;

        public UI() {
            font = Globals.Content.Load<SpriteFont>("Fonts\\arial16");
        }

        public void Update(Prota _protagonista) {
            Vida = $"Puntos de vida: {_protagonista.HP}";
        }

        public void Draw() {
            string debugStr = Globals.debugConsole;
            Vector2 dbstrDims = font.MeasureString(debugStr);
            Globals.SpriteBatch.DrawString(font, debugStr, new(Globals.WindowSize.X / 2 - dbstrDims.X/2, Globals.WindowSize.Y), Color.Black);

            string FelicidadesShinji = "FELICIDADES!!!! ganaste :P";
            Globals.SpriteBatch.DrawString(font, FelicidadesShinji, new(10, 20), Color.Black);

            DrawHUD();
        }

        public void DrawHUD() {
            Globals.SpriteBatch.End();
            Globals.SpriteBatch.Begin();

            Globals.SpriteBatch.DrawString(font, Vida, new(10, 0), Color.Black);
            if (!Globals.protaVivo) {
                string panqueque = "Te moriste :(";
                Vector2 strDms = font.MeasureString(panqueque);
                Globals.SpriteBatch.DrawString(font, panqueque, new(Globals.Viewport.Width / 2 - strDms.X / 2, Globals.Viewport.Height / 2), Color.Black);
            }

            Globals.SpriteBatch.End();
            Globals.SpriteBatch.Begin(transformMatrix: Globals.viewMatrix);
        }
    }
}
