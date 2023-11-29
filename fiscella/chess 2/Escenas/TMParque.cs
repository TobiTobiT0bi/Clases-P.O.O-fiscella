using chess_2.Objetos;
using chess_2.Enemigos;
using MonoGame.Aseprite.Content.Processors;
using MonoGame.Aseprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace chess_2.Escenas
{
    internal class TMParque : TileMap
    {
        public List<PiezaDamas> enemigos = new List<PiezaDamas>();

        public TMParque() : base() { 
            LoadContent();
        }

        public override void Update()
        {
            foreach (var enemigo in enemigos) { 
                enemigo.Update();
            }
            UpdateExist();
            Globals.enemyRectangles.Clear();
            foreach (var item in enemigos)
            {
                Globals.enemyRectangles.Add(item.GetRectangle());
            }
        }

        public override void LoadContent()
        {
            base.LoadContent();
            aseFile = AsepriteFile.Load("E:\\repos\\Clases-P.O.O-fiscella\\fiscella\\chess 2\\Content\\img\\Mapas_tsx\\Nivel1.aseprite");
            _tilemap = TilemapProcessor.Process(Globals.GraphicsDevice, aseFile, frameIndex: 0);

            enemigos.Add(new(Globals.Content.Load<Texture2D>("img/Damas/piezaSing"), new(11 * Globals.TileSize.X, 46 * Globals.TileSize.X + Globals.Content.Load<Texture2D>("img/Damas/piezaSing").Height / 2), 4 * Globals.TileSize.X));
            enemigos.Add(new(Globals.Content.Load<Texture2D>("img/Damas/piezaSing"), new(13 * Globals.TileSize.X, 46 * Globals.TileSize.X + Globals.Content.Load<Texture2D>("img/Damas/piezaSing").Height / 2), 4 * Globals.TileSize.X));

            enemigos.Add(new(Globals.Content.Load<Texture2D>("img/Damas/piezaSing"), new(42 * Globals.TileSize.X, 33 * Globals.TileSize.X + Globals.Content.Load<Texture2D>("img/Damas/piezaSing").Height / 2), 4 * Globals.TileSize.X));

            enemigos.Add(new(Globals.Content.Load<Texture2D>("img/Damas/piezaSing"), new(39 * Globals.TileSize.X, 9 * Globals.TileSize.X + Globals.Content.Load<Texture2D>("img/Damas/piezaSing").Height / 2), 4 * Globals.TileSize.X));
            enemigos.Add(new(Globals.Content.Load<Texture2D>("img/Damas/piezaSing"), new(43 * Globals.TileSize.X, 9 * Globals.TileSize.X + Globals.Content.Load<Texture2D>("img/Damas/piezaSing").Height / 2), 4 * Globals.TileSize.X));
            enemigos.Add(new(Globals.Content.Load<Texture2D>("img/Damas/piezaSing"), new(54 * Globals.TileSize.X, 9 * Globals.TileSize.X + Globals.Content.Load<Texture2D>("img/Damas/piezaSing").Height / 2), 4 * Globals.TileSize.X));
            enemigos.Add(new(Globals.Content.Load<Texture2D>("img/Damas/piezaSing"), new(60 * Globals.TileSize.X, 9 * Globals.TileSize.X + Globals.Content.Load<Texture2D>("img/Damas/piezaSing").Height / 2), 4 * Globals.TileSize.X));           
        }

        public override void Draw()
        {
            base.Draw();
            foreach (var enemigo in enemigos)
            {
                enemigo.Draw();
            }
        }

        public void UpdateExist() {

            for (int i = 0; i < Globals.enemyRectangles.Count; i++) {
                if (Globals.enemyRectangles[i].IsEmpty) { 
                    Globals.enemyRectangles.RemoveAt(i);
                    enemigos.RemoveAt(i);
                }
            }
        }

        public List<PiezaDamas> GetEnemigos()
        {
            return enemigos;
        }

        public override void DrawDebug() {
            Texture2D pixel = new Texture2D(Globals.GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });

            foreach(var enemigo in enemigos)
            {
                Globals.SpriteBatch.Draw(pixel, new Rectangle((int)enemigo.GetRectangle().X, (int)enemigo.GetRectangle().Y, enemigo.GetRectangle().Width, enemigo.GetRectangle().Height), Color.White * 0.5f);
            }
        }
    }
}
