using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2.Objetos
{
    internal class Prota : Sprite
    {
        private const float SPEED = 750f;
        private const float GRAVITY = 5000f;
        private const float JUMP = 1500f;
        private Vector2 _velocidad;
        private bool _OnGround = true;

        public Prota(Texture2D texture, Vector2 position) : base(texture, position) { 
            
        }

        private void UpdateVelocity() { 
            var teclao = Keyboard.GetState();

            if (teclao.IsKeyDown(Keys.Left))
            {
                _velocidad.X = -SPEED;
            }
            else if (teclao.IsKeyDown(Keys.Right))
            {
                _velocidad.X = SPEED;
            }
            else {
                _velocidad.X = 0;
            }

            if (!_OnGround) {
                _velocidad.Y += GRAVITY * Globals.Time;
            }

            if (teclao.IsKeyDown(Keys.Space) && _OnGround) {
                _velocidad.Y = -JUMP;
                _OnGround = false;
            }
        }

        public void Update() {
            UpdateVelocity();
            Position += _velocidad * Globals.Time;
        }
    }
}
