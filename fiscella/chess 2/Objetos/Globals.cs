using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2.Objetos
{
    public static class Globals
    {
        public static float Time { get; set; }

        public static float TimeMiliseconds { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static GraphicsDevice GraphicsDevice { get; set; }
        public static Point WindowSize { get; set; }
        public static string Scene { get; set; }
        public static Matrix viewMatrix { get; set; }


        public static List<Rectangle> SceneRectangles { get; set; }
        public static Random rnd { get; set; } = new();

        public static bool Debug { get; set; } 

        public static void Update(GameTime gt)
        {
            Time = (float)gt.ElapsedGameTime.TotalSeconds;
            TimeMiliseconds = (float)gt.ElapsedGameTime.TotalMilliseconds;
        }

        public static float RandomFloat(float min, float max) {
            return (float)(rnd.NextDouble() * (max - min)) + min;
        }
    }
}
