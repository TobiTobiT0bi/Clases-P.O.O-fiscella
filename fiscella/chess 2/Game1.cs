using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;

namespace chess_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        // Encarga de dibujar las texturas en pantalla.
        private SpriteBatch _spriteBatch;
        // Crea la variable de textura 2D "pruebas".
        private Texture2D _pruebasTexture;
        // Crea la variable de posición de "pruebas"
        private Vector2 _pruebasPosition;
        // Crea la variable de la velocidad en la que se moverá el sprite.
        private Vector2 _pruebasSpeed = new Vector2(3, 3);

        private Texture2D _manzanaTexture;
        private Vector2 _manzanaPosition;

        private Song _backgroundMusic;

        private bool _manzanaTocada = false; // Bandera para controlar si se tocó la manzana

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Permite calcular los graficos(?)
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Carga la textura "pruebas" en la variable.
            _pruebasTexture = Content.Load<Texture2D>("img/prueba");
            // Define la posición de inicio del sprite "pruebas".
            _pruebasPosition = new Vector2(100, 100);


            // Carga las textura "manzana" en la variable.
            _manzanaTexture = Content.Load<Texture2D>("img/manzana");
            // (?)
            _manzanaPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 - _manzanaTexture.Width / 2, GraphicsDevice.Viewport.Height / 2 - _manzanaTexture.Height / 2);

            _backgroundMusic = Content.Load<Song>("background_music");
            MediaPlayer.Play(_backgroundMusic);
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            // Se utiliza para poder recibir el estado del teclado.
            KeyboardState keyboardState = Keyboard.GetState();

            // Se ejecuta cuando la variable _manzanaTocada es "false".
            if (!_manzanaTocada)
            {
                // Movimiento del sprite "pruebas" controlado por las flechas del teclado

                // Cuando se aprieta la tecla "left" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Left))
                    // Se resta la posición actual en "X" por el valor de la velocidad. Si velocidad es 2 se restan 2 posiciones.
                    _pruebasPosition.X -= 2;

                // Cuando se aprieta la tecla "right" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Right))
                    // Se suma la posición actual en "X" por el valor de la velocidad.
                    _pruebasPosition.X += 2;

                // Cuando se aprieta la tecla "up" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Up))
                    // Se resta la posición actual en "Y" por el valor de la velocidad.
                    _pruebasPosition.Y -= 2;

                // Cuando se aprieta la tecla "down" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Down))
                    // Se suma la posición actual en "Y" por el valor de la velocidad.
                    _pruebasPosition.Y += 2;

                // Verificar colisión con la manzana
                Rectangle pruebasRectangle = new Rectangle((int)_pruebasPosition.X, (int)_pruebasPosition.Y, _pruebasTexture.Width, _pruebasTexture.Height);
                // Es la caja de coliciones de "pruebas" y se basa en el tamaño de la imgane.
                Rectangle manzanaRectangle = new Rectangle((int)_manzanaPosition.X, (int)_manzanaPosition.Y, _manzanaTexture.Width, _manzanaTexture.Height);
                // Es la caja de coliciones de "manzana" y se basa en el tamaño de la imgane.

                if (pruebasRectangle.Intersects(manzanaRectangle))
                {
                    _manzanaTocada = true;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Limpia 20 veces por segundo la imagen.

            _spriteBatch.Begin();
            _spriteBatch.Draw(_pruebasTexture, _pruebasPosition, Color.White);
            if(!_manzanaTocada)
                _spriteBatch.Draw(_manzanaTexture, _manzanaPosition, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
