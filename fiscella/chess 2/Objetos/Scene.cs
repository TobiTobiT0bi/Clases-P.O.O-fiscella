using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2.Objetos
{
    public class Scene
    {
        public string fondo { get; }

        public Scene() {
            Globals.Scene = fondo;
        }

        public virtual List<Rectangle> GetRectangles() {
            return new();
        }

        public virtual string GetFondo() {
            return fondo;
        }

        public virtual void LoadFondo() {
            Globals.Scene = fondo;
        }

        public virtual void Draw() { 
        
        }

        public virtual void BackgroundDraw() {
        
        }
    }
}
