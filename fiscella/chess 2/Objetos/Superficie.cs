using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace chess_2.Objetos
{
    internal class Superficie : Sprite
    {
        public Rectangle Rectangle { get; set; }

        public Superficie(Texture2D texture, Vector2 position) : base(texture, position) {

            Rectangle = new((int)position.X, (int)position.Y, texture.Width, texture.Height);

        }
    }
}
