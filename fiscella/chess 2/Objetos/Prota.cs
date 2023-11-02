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
        private const float DASH = 3.5f;
        private const float GRAVITY = 5000f;
        private const float JUMP = 1500f;
        private Vector2 _velocidad;
        private bool _OnGround = true;
        private bool _DashRecharged = true;
        private bool _isDashing = false;
        private string _facing = "der";
        private float _elapsedDash = 0;
        private float _dashTime = 0;

        public Prota(Texture2D texture, Vector2 position) : base(texture, position) { 
            
        }

        private void Dash(KeyboardState teclao) {
            if (teclao.IsKeyDown(Keys.C))
            {
                if (DashPosible() && _DashRecharged && !_isDashing) {
                    _DashRecharged = false;
                    _isDashing = true;  
                    Dash();
                }
            }
        }

        private void Jump(KeyboardState teclao) {
            if (teclao.IsKeyDown(Keys.Space) && _OnGround)
            {
                _velocidad.Y = -JUMP;
                _OnGround = false;
            }
        }

        private void UpdateVelocity() { 
            var teclao = Keyboard.GetState();        

            if (teclao.IsKeyDown(Keys.Left))
            {
                _velocidad.X = -SPEED;
                _facing = "izq";

            }
            else if (teclao.IsKeyDown(Keys.Right))
            {
                _velocidad.X = SPEED;
                _facing = "der";
                          
            }
            else {
                _velocidad.X = 0;
            }          

            if (teclao.IsKeyDown(Keys.LeftShift))
            {
                _velocidad.X = _velocidad.X * RUNNING;
            }

            if (!_OnGround) {
                _velocidad.Y += GRAVITY * Globals.Time;
            }

            Dash(teclao);
            if (_isDashing)
            {
                Dash();
                if (_dashTime >= 2000)
                {
                    _isDashing = false;
                    _dashTime = 0;
                }
            }
            Jump(teclao);     
        }

        private void UpdatePosition() { 
            Rectangle rectangle;
            _OnGround = false;
            var newPos = Position + (_velocidad * Globals.Time);
            _elapsedDash += Globals.TimeMiliseconds;
            _dashTime += _isDashing ? _dashTime + Globals.TimeMiliseconds : 0;

            foreach (Rectangle SceneRectangle in Globals.SceneRectangles) 
            {
                if (newPos.X != Position.X)
                {
                    rectangle = new Rectangle((int)newPos.X, (int)Position.Y, Texture.Width, Texture.Height);
                    if (rectangle.Intersects(SceneRectangle)) 
                    {
                        if (newPos.X > Position.X) {
                            newPos.X = SceneRectangle.Left - Texture.Width;
                            _velocidad.X = 0;
                        }
                        else {
                            newPos.X = SceneRectangle.Right;
                            _velocidad.X = 0;
                        }
                        continue;
                    }

                }

                rectangle = new((int)Position.X, (int)newPos.Y, Texture.Width, Texture.Height);
                if (rectangle.Intersects(SceneRectangle)) 
                {
                    if (_velocidad.Y > 0)
                    {
                        newPos.Y = SceneRectangle.Top - Texture.Height;
                        _OnGround = true;
                        _velocidad.Y = 0;
                    }
                    else {
                        newPos.Y = SceneRectangle.Bottom;
                        _velocidad.Y = 0;
                    }
                }
            }

            Position = newPos;          

            if (_elapsedDash >= 1000) { 
                _DashRecharged = true;
                _elapsedDash = 0;
            }
        }

        private bool DashPosible()
        {
            Rectangle rectangle;
            var newPos = Position + (_velocidad * Globals.Time);
            var newPosNext = Position + (new Vector2(_facing == "der" ? 1 : -1, 1));

            bool posible = true;

            foreach (Rectangle SceneRectangle in Globals.SceneRectangles)
            {

                rectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
                if (rectangle.Intersects(SceneRectangle)) { 
                    posible = false;
                }

                
                if (newPos.X != Position.X)
                {
                    rectangle = new Rectangle((int)newPos.X, (int)Position.Y, Texture.Width, Texture.Height);
                    if (rectangle.Intersects(SceneRectangle))
                    {
                        posible = false;
                        continue;
                    }                   
                }
                if (newPosNext.X != Position.X) {
                    rectangle = new Rectangle((int)newPosNext.X, (int)Position.Y, Texture.Width, Texture.Height);
                    if (rectangle.Intersects(SceneRectangle))
                    {
                        posible = false;
                        continue;
                    }
                }



                rectangle = new((int)Position.X, (int)newPos.Y, Texture.Width, Texture.Height);
                if (rectangle.Intersects(SceneRectangle))
                {
                    posible = false;
                }
            }

            return posible;
        }

        public void Dash() {
            _velocidad.Y = 0;
            _velocidad.X = (_facing == "der" ? SPEED : -SPEED) * DASH;
            _DashRecharged = false;
        }

        public void Update() {
            UpdateVelocity();
            UpdatePosition();
        }
    }
}
