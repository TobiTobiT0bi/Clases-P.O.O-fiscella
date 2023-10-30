using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;
using chess_2.Managers;

namespace chess_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        // Encarga de dibujar las texturas en pantalla.
        private SpriteBatch _spriteBatch;

        private GameManager _gameManager;

        private Texture2D _manzanaTexture;
        private Vector2 _manzanaPosition;

        private Texture2D _fondoTexture;
        private Vector2 _fondoPosition;

        private Texture2D _pisoTexture;
        private Vector2 _pisoPosition;

        private Plataforma plataforma1;
        private Plataforma plataforma2;

        private List<Plataforma> plataformas = new List<Plataforma>();

        private Texture2D _pixelTexture;

        private Texture2D _pochitaTexture;
        private Vector2 _pochitaPosition;

        private Texture2D _ganasteTexture;
        private Vector2 _ganastePosition;

        private Texture2D _pochitaIconoTexture;
        private Vector2 _pochitaIconoPosition;

        //private Song _backgroundMusic;

        private bool _manzanaTocada = false; // Bandera para controlar si se tocó la manzana
        private bool _pochitaTocada = false;
        private bool _enPiso = false;
        float limite;
        float framesSalto = 250;

        private bool salto = true;

        private string escena = "main";

        Rectangle pisoRectangle;
        Rectangle peonRectangleBody;
        Rectangle manzanaRectangle;
        Rectangle pochitaRectangle;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
        }

        protected override void Initialize()
        {
            Globals.WindowSize = new(800, 600);

            Globals.Content = Content;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.GraphicsDevice = GraphicsDevice;

            _gameManager = new GameManager();

            // Permite calcular los graficos(?)
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Carga la textura "pruebas" en la variable.

            plataforma1 = new Plataforma("plataformaGrande", 120, 350);
            plataforma2 = new Plataforma("plataformaGrande", 520, 350);

            plataformas.Add(plataforma1);
            plataformas.Add(plataforma2);

            //pixel 1x1 para debug
            _pixelTexture = new Texture2D(GraphicsDevice, 1, 1); _pixelTexture.SetData(new[] { Color.White });

            // Carga las textura "manzana" en la variable.
            _manzanaTexture = Content.Load<Texture2D>("img/manzana");
            _manzanaPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 - _manzanaTexture.Width / 2, GraphicsDevice.Viewport.Height / 2 - _manzanaTexture.Height / 2);

            _fondoTexture = Content.Load<Texture2D>("img/scenes/taverna");
            _fondoPosition = new Vector2(0, 0);

            // Carga las textura "pochita" en la variable.
            _pochitaTexture = Content.Load<Texture2D>("img/pochita");
            _pochitaPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 - _pochitaTexture.Width / 2, GraphicsDevice.Viewport.Height / 2 - _pochitaTexture.Height / 2);

            _ganasteTexture = Content.Load<Texture2D>("texto/ganaste");
            _ganastePosition = new Vector2(40, 0);

            _pochitaIconoTexture = Content.Load<Texture2D>("img/pochitaicono");
            _pochitaIconoPosition = new Vector2(10, 0);

            _pisoTexture = Content.Load<Texture2D>("img/scenes/PisoPiedra");
            _pisoPosition = new Vector2(0, GraphicsDevice.Viewport.Height - 62);

            //_backgroundMusic = Content.Load<Song>("background_music");
            //MediaPlayer.Play(_backgroundMusic);
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            // Se utiliza para poder recibir el estado del teclado.
            KeyboardState keyboardState = Keyboard.GetState();

            /*do you believe inGravity();//? */

            for (int i = 0; i < plataformas.Count; i++) {
                plataformas[i].LoadContent(Content);
            }
           
            // Movimiento del sprite "pruebas" controlado por las flechas del teclado

            /* Cuando se aprieta la tecla "left" se hace la siguiente operación:
            if (keyboardState.IsKeyDown(Keys.Left))
                // Se resta la posición actual en "X" por el valor de la velocidad. Si velocidad es 2 se restan 2 posiciones.
                _pruebasPosition.X -= 6;

            // Cuando se aprieta la tecla "right" se hace la siguiente operación:
            if (keyboardState.IsKeyDown(Keys.Right))
                // Se suma la posición actual en "X" por el valor de la velocidad.
                _pruebasPosition.X += 6;

            // Cuando se aprieta la tecla "up" se hace la siguiente operación:
            if (keyboardState.IsKeyDown(Keys.Up)) {
                // Se resta la posición actual en "Y" por el valor de la velocidad.
                Jump(limite);
            }

            // Cuando se aprieta la tecla "down" se hace la siguiente operación:
            if (keyboardState.IsKeyDown(Keys.Down))
            // Se suma la posición actual en "Y" por el valor de la velocidad.
            if (_pruebasPosition.Y <= 350) {
                _pruebasPosition.Y += 6;
            }

            
            // Verificar colisión con la manzana
            peonRectangleBody = new Rectangle((int)_pruebasPosition.X, (int)_pruebasPosition.Y, _pruebasTexture.Width, _pruebasTexture.Height); */


            // Es la caja de coliciones de "pruebas" y se basa en el tamaño de la imgane.
            manzanaRectangle = new Rectangle((int)_manzanaPosition.X, (int)_manzanaPosition.Y, _manzanaTexture.Width, _manzanaTexture.Height);
            // Es la caja de coliciones de "manzana" y se basa en el tamaño de la imgane.
            pochitaRectangle = new Rectangle((int)_pochitaPosition.X, (int)_pochitaPosition.Y, _pochitaTexture.Width, _pochitaTexture.Height);
            // Es la caja de coliciones de "manzana" y se basa en el tamaño de la imgane.
            pisoRectangle = new Rectangle((int)_pisoPosition.X - 125, (int)_pisoPosition.Y, _pisoTexture.Width + 250, _pisoTexture.Height);
            // Es la caja de coliciones de "manzana" y se basa en el tamaño de la imgane.

            for (int i = 0; i < plataformas.Count; i++) {
                plataformas[i].Rectangulo();
            }

            if (peonRectangleBody.Intersects(pochitaRectangle) && escena == "pochita")
            {
                _pochitaTocada = true;
            }

            if (peonRectangleBody.Intersects(manzanaRectangle) && escena == "main" && _pochitaTocada)
            {
                _manzanaTocada = true;
            }

            if (escena == "pochita") {
                _enPiso = IntersectsPlatform(plataformas, peonRectangleBody);
            }

            if (peonRectangleBody.Intersects(pisoRectangle)) {
                UpdateLimite();
                _enPiso = true;
            }

            Globals.Update(gameTime);
            _gameManager.Update();

            base.Update(gameTime);
        }

        public void UpdateLimite() {
            //limite = _pruebasPosition.Y - framesSalto;
        }

        private bool IntersectsPlatform(List<Plataforma> plataformasLista, Rectangle pruebasRectangle) {
            for (int i = 0; i < plataformasLista.Count; i++) {
                if (pruebasRectangle.Intersects(plataformasLista[i]._Bounds)) {
                    //_pruebasPosition.Y = plataformasLista[i]._Position.Y - _pruebasTexture.Height + 7;
                    UpdateLimite();
                    return true;
                }
            }

            return false;
        }

        //private void cambiarescena()
        //{

        //    if (_pruebasposition.x <= -125 && escena == "main")
        //    {
        //        escena = "pochita";
        //        _pruebasposition.x = 900;
        //        _pruebasposition.y = 328;
        //        _enpiso = false;
        //    }

        //    if (_pruebasposition.x > 900 && escena == "pochita")
        //    {
        //        escena = "main";
        //        _pruebasposition.x = -125;
        //        _pruebasposition.y = 285;
        //        _enpiso = false;
        //    }


        //}

        //private void jump(float limite)
        //{
        //    if (_pruebasposition.y >= limite)
        //    {
        //        if (salto == true)
        //        {
        //            _enpiso = false;
        //            _pruebasposition.y -= 30;
        //        }
        //    }
        //    else
        //    {
        //        salto = false;
        //    }
        //}

        public void Debug(SpriteBatch spriteBatch) {
            if (escena == "pochita") {
                spriteBatch.Draw(_pixelTexture, plataformas[1]._Bounds, Color.White * 0.3f);
                spriteBatch.Draw(_pixelTexture, plataformas[0]._Bounds, Color.White * 0.3f);
                spriteBatch.Draw(_pixelTexture, pochitaRectangle, Color.White * 0.3f);
            }
            spriteBatch.Draw(_pixelTexture, pisoRectangle, Color.White * 0.3f);
            spriteBatch.Draw(_pixelTexture, peonRectangleBody, Color.White * 0.3f);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Limpia 20 veces por segundo la imagen.

            _spriteBatch.Begin();
            _spriteBatch.Draw(_fondoTexture, _fondoPosition, Color.White);
            _spriteBatch.Draw(_pisoTexture, _pisoPosition, Color.White);

            if (_pochitaTocada) {
                _spriteBatch.Draw(_pochitaIconoTexture, _pochitaIconoPosition, Color.White);
            }

            if (escena == "main") {
                if (!_manzanaTocada)
                {
                    _spriteBatch.Draw(_manzanaTexture, _manzanaPosition, Color.White);
                }
                else
                {
                    _spriteBatch.Draw(_ganasteTexture, _ganastePosition, Color.White);
                }
            }
            else if(escena == "pochita") {
                if (!_pochitaTocada) {
                    _spriteBatch.Draw(_pochitaTexture, _pochitaPosition, Color.White);
                }

                for (int i = 0; i < plataformas.Count; i++) {
                    plataformas[i].Dibujo(_spriteBatch);
                }
            }

            Debug(_spriteBatch);

            _gameManager.Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
