using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;
using chess_2.Managers;
using chess_2.Objetos;
using chess_2.Escenas;
using TiledSharp;

namespace chess_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private GameManager _gameManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Globals.WindowSize = new(800, 600);
            Globals.Debug = false;
            Globals.debugConsole = "";
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            _graphics.ApplyChanges();

            Globals.Viewport = GraphicsDevice.Viewport;
            Globals.viewMatrix = new Matrix();
            Globals.SceneRectangles = new Rectangle[1616 / 16, 800 / 16];
            Globals.enemyRectangles = new List<Rectangle>();
            Globals.Content = Content;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.GraphicsDevice = GraphicsDevice;

            _gameManager = new GameManager();
            _gameManager._SceneManager.LoadScene(new TMParque());
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
            }
            Globals.Update(gameTime);

            _gameManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Globals.SpriteBatch.Begin(transformMatrix: Globals.viewMatrix);

            _gameManager.Draw();

            Globals.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
