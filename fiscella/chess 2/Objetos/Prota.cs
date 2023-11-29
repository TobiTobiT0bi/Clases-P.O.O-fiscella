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
    public class Prota : Sprite
    {
        private const float SPEED = 250f;
        private const float RUNNING = 1.5f;
        private const float DASH = 3.5f;
        private const float GRAVITY = 5000f;
        private const float JUMP = 850f;
        private const int OFFSET = 4;
        private Vector2 _velocidad;
        private Vector2 _minPos, _maxPos;
        public int HP = 3;
        public bool vivo = true;

        private bool _OnGround = true;
        private bool _DashRecharged = true;
        private bool _isDashing = false;
        private bool _attackRecharged = true;
        public bool _isSlashing = false;
        public bool _isAttacking = false;
        public bool _isBeingHurt = false;
        public bool _hurtRecharged = true;

        private bool _slash = false;
        private bool _lightAttack = false;

        private string _facing = "der";
        private float _elapsedDash = 0;
        private float _elapsedSlash = 0;
        private float _elapsedAttack = 0;
        private float _elapsedHurt = 0;
        private float _dashTime = 0;
        private float _slashTime = 0;
        private float _attackTime = 0;
        private float _hurtTime = 0;

        private Sprite slash = new(Globals.Content.Load<Texture2D>("img/assets/slash"), new(0,0));
        private Sprite attackRight = new(Globals.Content.Load<Texture2D>("img/assets/attackRight"), new(0, 0));
        private Sprite attackLeft = new(Globals.Content.Load<Texture2D>("img/assets/attackLeft"), new(0, 0));

        private Rectangle slashRect;
        private Rectangle attackRect;

        public Prota(Texture2D texture, Vector2 position) : base(texture, position) {
            Globals.prota = this;
        }

        private void Dash(KeyboardState teclao) {
            if (teclao.IsKeyDown(Keys.LeftControl))
            {
                if (DashPosible() && _DashRecharged && !_isDashing) {
                    _DashRecharged = false;
                    _isDashing = true;  
                    DashExe();
                }
            }
        }

        private void Jump(KeyboardState teclao) {
            if ((teclao.IsKeyDown(Keys.Space) || teclao.IsKeyDown(Keys.Up))&& _OnGround)
            {
                _velocidad.Y = -JUMP;
                _OnGround = false;
            }
        }

        private void AttackSlash(KeyboardState teclao) {
            if (teclao.IsKeyDown(Keys.X) && _attackRecharged && !_isSlashing) {
                slash.Position = _facing == "der" ? new(Position.X + Texture.Width, Position.Y + Texture.Height / 2 - slash.Texture.Height / 2) : new(Position.X - slash.Texture.Width, Position.Y + Texture.Height / 2 - slash.Texture.Height / 2);
                _isSlashing = true;
                _slash = true;
                slashRect = new((int)slash.Position.X, (int)slash.Position.Y, slash.Texture.Width, slash.Texture.Height);
                for(int i = 0; i < Globals.enemyRectangles.Count; i++) {
                    if (slashRect.Intersects(Globals.enemyRectangles[i])) { 
                        Globals.enemyRectangles[i] = new(0, 0, 0, 0);
                    }
                }
            }
        }

        private void AttackLight(KeyboardState teclao) {
            if (teclao.IsKeyDown(Keys.C) && _attackRecharged && !_isAttacking) {
                if (_facing == "der") {
                    attackRight.Position = new(Position.X + Texture.Width, Position.Y + Texture.Height / 2 - attackRight.Texture.Height / 2);
                    attackRect = new((int)attackRight.Position.X, (int)attackRight.Position.Y, attackRight.Texture.Width, attackRight.Texture.Height);
                }
                else {
                    attackLeft.Position = new(Position.X - attackLeft.Texture.Width, Position.Y + Texture.Height / 2 - attackLeft.Texture.Height / 2);
                    attackRect = new((int)attackLeft.Position.X, (int)attackLeft.Position.Y, attackLeft.Texture.Width, attackLeft.Texture.Height);
                }              
                _isAttacking = true;
                _lightAttack = true;
                for (int i = 0; i < Globals.enemyRectangles.Count; i++)
                {
                    if (attackRect.Intersects(Globals.enemyRectangles[i]))
                    {
                        Globals.enemyRectangles[i] = new(0, 0, 0, 0);
                    }
                }

            }
        }

        private Rectangle CalculateBounds(Vector2 pos) {
            return new((int)pos.X + OFFSET, (int)pos.Y, Texture.Width - (2 * OFFSET), Texture.Height);
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
            
            AttackSlash(teclao);
            AttackLight(teclao);
            
            Jump(teclao);     
        }

        private void UpdateActions() {
            _dashTime += _isDashing ? _dashTime + Globals.TimeMiliseconds : 0;
            _slashTime += _isSlashing ? _slashTime + Globals.Time : 0;
            _attackTime += _isAttacking ? _attackTime + Globals.Time : 0;
            _elapsedDash += Globals.TimeMiliseconds;
            _elapsedSlash += Globals.TimeMiliseconds;
            _elapsedAttack += Globals.TimeMiliseconds;
          
            _hurtTime += _isBeingHurt ? _hurtTime + Globals.TimeMiliseconds : 0; _elapsedHurt += Globals.TimeMiliseconds;

            if (_isDashing)
            {
                DashExe();
                if (_dashTime >= 2000)
                {
                    _isDashing = false;
                    _dashTime = 0;
                }
            }

            if (_elapsedDash >= 1000)
            {
                _DashRecharged = true;
                _elapsedDash = 0;
            }

            if (_isSlashing)
            {
                _attackRecharged = false;
                Stop();
                if (_slashTime >= 5000)
                {
                    _isSlashing = false;

                    _slash = false;

                    _slashTime = 0;

                    slashRect = default(Rectangle);
                }
            }

            if (_elapsedSlash >= 1000)
            {
                _attackRecharged = true;
                _elapsedSlash = 0;
            }

            if (_isAttacking)
            {
                _attackRecharged = false;
                if (_facing == "der")
                {
                    attackRight.Position = new(Position.X + Texture.Width, Position.Y + Texture.Height / 2 - attackRight.Texture.Height / 2);
                }
                else
                {
                    attackLeft.Position = new(Position.X - attackLeft.Texture.Width, Position.Y + Texture.Height / 2 - attackLeft.Texture.Height / 2);
                }

                if (_attackTime >= 500)
                {
                    _isAttacking = false;

                    _lightAttack = false;

                    _attackTime = 0;

                    attackRect = default(Rectangle);
                }
            }

            if (_elapsedAttack >= 500)
            {
                _attackRecharged = true;
                _elapsedAttack = 0;
            }

            if (_isBeingHurt)
            {
                _hurtRecharged = false;
                if (_hurtTime >= 5000)
                {
                    _isBeingHurt = false;

                    _hurtTime = 0;

                    slashRect = default(Rectangle);
                }
            }

            if (_elapsedHurt >= 1000)
            {
                _hurtRecharged = true;
                _elapsedHurt = 0;
            }
        }

        private void UpdatePosition() {
            Rectangle rectangle;
            _OnGround = false;
            var newPos = Position + (_velocidad * Globals.Time);

            foreach (Rectangle SceneRectangle in Globals.SceneRectangles)
            {
                if (newPos.X != Position.X)
                {
                    rectangle = new Rectangle((int)newPos.X, (int)Position.Y, Texture.Width, Texture.Height);
                    if (rectangle.Intersects(SceneRectangle))
                    {
                        if (newPos.X > Position.X)
                        {
                            newPos.X = SceneRectangle.Left - Texture.Width;
                            _velocidad.X = 0;
                        }
                        else
                        {
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
                    else if (Position.Y > SceneRectangle.Bottom)
                    {
                        newPos.Y = SceneRectangle.Bottom;
                        _velocidad.Y = 0;
                    }
                }
            }

            Position = newPos;
            Position.X = MathHelper.Clamp(Position.X, 0, Globals.MapSize.X);
        }

        public void UpdateVida()
        {
            Rectangle rec = new((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

            foreach (var enemyRec in Globals.enemyRectangles) { 
                if (rec.Intersects(enemyRec) &&_hurtRecharged && !_isBeingHurt) {
                    HP--;
                    _isBeingHurt = true;
                }
            }

            if (HP <= 0) vivo = false; 
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

        public void DashExe() {
            Stop((_facing == "der" ? SPEED : -SPEED) * DASH);
            _DashRecharged = false;
        }

        public void Stop(float x = 0, float y = 0) {
            _velocidad.X = x;
            _velocidad.Y = y;
        }

        public void setBounds() {
            _minPos = new((-Globals.TileSize.X / 2) + Texture.Width / 2, (-Globals.TileSize.Y / 2) + Texture.Height / 2);
            _maxPos = new(Globals.MapSize.X - (Globals.TileSize.X / 2) + Texture.Width / 2, Globals.MapSize.Y - (Globals.TileSize.Y / 2) + Texture.Height / 2);
        }

        public void Update() {
            if (vivo)
            {
                UpdateVelocity();
                UpdateActions();
                UpdatePosition();
                UpdateVida();
            }
            else { 
                Globals.protaVivo = false;
            }
        }

        public override void Draw()
        {
            if (vivo) {
                base.Draw();
                if (_isSlashing && _slash) { Globals.SpriteBatch.Draw(slash.Texture, slash.Position, Color.White); }
                if (_isAttacking && _lightAttack)
                {
                    if (_facing == "der")
                    {
                        Globals.SpriteBatch.Draw(attackRight.Texture, attackRight.Position, Color.White);
                    }
                    else
                    {
                        Globals.SpriteBatch.Draw(attackLeft.Texture, attackLeft.Position, Color.White);
                    }
                }
            }          
        }
    }
}
