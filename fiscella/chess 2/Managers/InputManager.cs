using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace chess_2.Managers
{
    public static class InputManager
    {
        private static MouseState _LastMouseState;
        public static bool hasClicked { get; private set; }
        public static Vector2 mousePosition { get; private set; }

        public void Update() { 
            var MouseState = Mouse.GetState();

            hasClicked = MouseState.LeftButton == ButtonState.Pressed && _LastMouseState.LeftButton == ButtonState.Released;
        }
    }
}
