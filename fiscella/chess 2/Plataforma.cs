using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2
{
    internal class Plataforma
    {
        string nombre;
        int x;
        int y ;

        public Texture2D _Texture;
        public Vector2 _Position;
        public Rectangle _Bounds;

        public Plataforma(string nombre, int x = 0, int y = 0) { 
            this.nombre = nombre;
            this.x = x;
            this.y = y;

        }

        public void LoadContent(ContentManager content)
        {
            _Texture = content.Load<Texture2D>($"img/scenes/{nombre}");
            _Position = new Vector2(x, y);
        }

        public void Dibujo(SpriteBatch spriteBach) { 
            //spriteBach.Begin();

            spriteBach.Draw(_Texture, _Position, Color.White);

            //spriteBach.End();
        }

        public void Rectangulo() { 
            _Bounds = new Rectangle((int)_Position.X, (int)_Position.Y, _Texture.Width, _Texture.Height);
        }
    }
}
