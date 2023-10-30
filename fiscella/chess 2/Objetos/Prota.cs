using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_2.Managers;

namespace chess_2.Objetos
{
    internal class Prota : Sprite
    {
        private const float SPEED = 550f;
        private const float RUNNING = 1.5f;
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
                if (teclao.IsKeyDown(Keys.LeftShift))
                {
                    _velocidad.X = -SPEED * RUNNING;
                }
                else {
                    _velocidad.X = -SPEED;
                }
            }
            else if (teclao.IsKeyDown(Keys.Right))
            {
                if (teclao.IsKeyDown(Keys.LeftShift))
                {
                    _velocidad.X = SPEED * RUNNING;
                }
                else {
                    _velocidad.X = SPEED;
                }           
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

        private void UpdatePosition() { 
            
        }

        public void Update() {
            UpdateVelocity();
            Position += _velocidad * Globals.Time;
        }
    }
}
