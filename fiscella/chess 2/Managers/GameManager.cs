using chess_2.Objetos;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_2.Escenas;
using System.Runtime.ConstrainedExecution;
using SharpDX.D3DCompiler;

namespace chess_2.Managers
{
    internal class GameManager
    {
        public SceneManager _SceneManager { get; }
        public UI _ui;
        public Camara _camara;
        private readonly Prota _protagonista;

        
        public GameManager() {
            _SceneManager = new();
            _SceneManager.LoadScene(new TileMap());
            _protagonista = new(Globals.Content.Load<Texture2D>("img/chess/W_pawn"), new(15, Globals.MapSize.Y - Globals.TileSize.Y * 5));
            Globals.protaVivo = true;
            _protagonista.setBounds();

            _camara = new Camara();
            _camara.limits = new(0, 0, Globals.MapSize.X, Globals.MapSize.Y);
            _ui = new UI();
        }

        public void Update()
        {
            _camara.Update(_protagonista);
            _SceneManager.Update();
            _protagonista.Update();
            _ui.Update(_protagonista);
        }

        public void Draw()
        {         
            _SceneManager.Draw();
            _protagonista.Draw();
            if (Globals.Debug) {
                Debug();
            }

            _ui.Draw();
        }

        public void Debug() {
            Texture2D pixel = new Texture2D(Globals.GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });

            foreach (Rectangle rect in Globals.SceneRectangles) {
                Globals.SpriteBatch.Draw(pixel, rect, Color.White * 0.5f);
            }

            _SceneManager.escena.DrawDebug();

            Globals.SpriteBatch.Draw(pixel, new Rectangle((int)_protagonista.Position.X, (int)_protagonista.Position.Y, _protagonista.Texture.Width, _protagonista.Texture.Height), Color.White * 0.5f);
        }

        //public void CrearMatriz()
        //{
        //    float fx = Globals.WindowSize.X / 2;
        //    fx = MathHelper.Clamp(fx, -Globals.MapSize.X + Globals.WindowSize.X + (Globals.TileSize.X / 2), Globals.TileSize.X / 2 - 16);

        //    float fy = Globals.WindowSize.Y / 2;
        //    fy = MathHelper.Clamp(fy, -Globals.MapSize.Y + Globals.WindowSize.Y + (Globals.TileSize.Y / 2), Globals.TileSize.Y / 2 - 16);

        //    float lx = -_protagonista.Position.X;
        //    lx = MathHelper.Clamp(lx, -Globals.MapSize.Y + Globals.WindowSize.Y + (Globals.TileSize.Y / 2), Globals.TileSize.Y / 2);

        //    float ly = -_protagonista.Position.Y;
        //    ly = MathHelper.Clamp(ly, -Globals.MapSize.Y + Globals.WindowSize.Y + (Globals.TileSize.Y / 2), Globals.TileSize.Y / 2);

        //    Matrix lugar = Matrix.CreateTranslation(new Vector3(lx, ly, 0));
        //    Matrix escala = Matrix.CreateScale(1.5f);
        //    Matrix fijacion = Matrix.CreateTranslation(new Vector3(fx, fy, 0));

        //    Matrix final = lugar * escala * fijacion;


        //    Globals.viewMatrix = final;

        //    MatrizBounds(final);
        //}

        //public void MatrizBounds(Matrix transform)
        //{
        //    Matrix inverseTransform = Matrix.Invert(transform);
        //    Vector2 cameraPosition = new(inverseTransform[3, 0], inverseTransform[3, 1]);

        //    Globals.debugConsole = $"[3, 0] = {inverseTransform[3, 0]}, [3, 1] = {inverseTransform[3, 1]}";

        //    var cameraTopLeft = cameraPosition - new Vector2(Globals.WindowSize.X / 2, Globals.WindowSize.Y / 2);
        //    var cameraBottomRight = cameraPosition + new Vector2(Globals.WindowSize.X / 2, Globals.WindowSize.Y / 2);

        //    var cameraTopLeftWorld = Vector2.Transform(cameraTopLeft, inverseTransform);
        //    var cameraBottomRightWorld = Vector2.Transform(cameraBottomRight, inverseTransform);

        //    var width = cameraBottomRightWorld.X - cameraTopLeftWorld.X;
        //    var height = cameraBottomRightWorld.Y - cameraTopLeftWorld.Y;
        //    Rectangle bounds = new((int)cameraTopLeftWorld.X, (int)cameraTopLeftWorld.Y, (int)width, (int)height);


        //}
    }
}
