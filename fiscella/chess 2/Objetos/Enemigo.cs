using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2.Objetos
{
    internal class Enemigo : Sprite
    {
        Rectangle rectangle;
        Vector2 origin;
        Vector2 velocity;
        float rotation = 0f;

        bool der;
        float distance;
        float oldDistance;
        float protaDistance;

        public Enemigo(Texture2D texture, Vector2 position, float newDistance) : base(texture, position)
        {
            rectangle = new Rectangle(new((int)Position.X - Texture.Width / 2, (int)Position.Y - Texture.Height / 2), new(Texture.Width, Texture.Height));
            distance = newDistance;
            oldDistance = distance;
        }

        public virtual void UpdatePatrujalle() {
            Position += velocity;
            rectangle = new Rectangle(new((int)Position.X - Texture.Width / 2, (int)Position.Y - Texture.Height / 2), new(Texture.Width, Texture.Height));
            origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            if (distance <= 0)
            {
                der = true;
                velocity.X = 1f;
            }
            else if (distance >= oldDistance)
            {
                der = false;
                velocity.X = -1f;
            }


            distance = der ? distance + 1 : distance - 1;


            protaDistance = Globals.prota.Position.X - Position.X;

            
            if (protaDistance >= -200 && protaDistance <= 200)
            {
                if (protaDistance < -1)
                {
                    velocity.X = -1f;
                }
                else if (protaDistance > 1)
                {
                    velocity.X = 1f;
                }
                else if (protaDistance == 0)
                {
                    velocity.X = 0f;
                }
            }

            FixPos();
        }

        private void FixPos()
        {
            var newPos = Position + velocity;
            Rectangle newRec;

            foreach (Rectangle SceneRectangle in Globals.SceneRectangles)
            {
                if (newPos.X != Position.X)
                {
                    newRec = new Rectangle((int)newPos.X, (int)Position.Y - 15, Texture.Width, Texture.Height);
                    if (newRec.Intersects(SceneRectangle))
                    {
                        if (newPos.X > Position.X)
                        {
                            Position.X = SceneRectangle.Left - Texture.Width * 1.2f;
                            velocity.X = 0;
                        }
                        else
                        {
                            Position.X = SceneRectangle.Right + Texture.Width * 1.2f;
                            velocity.X = 0;
                        }
                    }

                }
            }
        }

        public void Update() {
            UpdatePatrujalle();
        }

        public Rectangle GetRectangle() { 
            return rectangle;
        }

        public override void Draw() {
            if (velocity.X > 0)
            {
                Globals.SpriteBatch.Draw(Texture, Position, null, Color.White, rotation, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
            }
            else {
                Globals.SpriteBatch.Draw(Texture, Position, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
