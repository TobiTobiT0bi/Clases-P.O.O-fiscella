using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2.Objetos
{
    internal class Sprite
    {
        public Texture2D Texture { get; }
        public Vector2 Position;

        public Sprite(Vector2 position)
        {
            Position = position;
        }

        public Sprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
