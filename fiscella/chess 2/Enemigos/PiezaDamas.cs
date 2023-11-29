using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_2.Objetos;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace chess_2.Enemigos
{
    internal class PiezaDamas : Enemigo
    {
        int hp = 3;

        public PiezaDamas(Texture2D texture, Vector2 position, float newDistance) : base(texture, position, newDistance)
        {
        }
    }
}
