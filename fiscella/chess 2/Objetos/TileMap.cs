using Assimp.Configs;
using Microsoft.Xna.Framework;
using MonoGame.Aseprite;
using MonoGame.Aseprite.Content.Processors;
using MonoGame.Aseprite.Tilemaps;
using System;
using System.Collections.Generic;

namespace chess_2.Objetos
{
    internal class TileMap
    {
        public AsepriteFile aseFile { get; set; }
        public Tilemap _tilemap { get; set; }

        Point tileSize = new Point(16, 16);
        Point mapTileSize = new Point(1616 / 16, 800 / 16);
        Point mapSize = new Point(1616, 800);

        public TileMap() {
            LoadContent();
        }

        public virtual void LoadContent() {
            aseFile = AsepriteFile.Load("E:\\repos\\Clases-P.O.O-fiscella\\fiscella\\chess 2\\Content\\img\\Mapas_tsx\\Nivel1.aseprite"); //No hay manera de utilzar el RootDirectory de Content, cambiar cada que sea descargado el repositorio en pc nueva
            _tilemap = TilemapProcessor.Process(Globals.GraphicsDevice, aseFile, frameIndex: 0);
            TilemapLayer layer = _tilemap.GetLayer(1);

            for (int x = 0; x < layer.Columns; x++) {
                for (int y = 1; y <= layer.Rows; y++) {
                    if (!layer[x, y - 1].IsEmpty) {
                        Globals.SceneRectangles[x, y - 1] = new Rectangle(new(x * tileSize.Y, y * tileSize.X), tileSize);
                    }
                }
            } 
            SetMapSize();
        }

        public virtual void Update() { 
            
        }

        public virtual void SetMapSize() {
            Globals.MapSize = new(tileSize.X * mapTileSize.X, tileSize.Y * mapTileSize.Y);
            Globals.TileSize = tileSize;
            Globals.tileMap = _tilemap;
        }

        public static List<Rectangle> getNearestColliders(Rectangle bounds) {
            int topTile = (int)Math.Floor((float)bounds.Top / Globals.TileSize.Y);
            int bottomTile = (int)Math.Ceiling((float)bounds.Bottom / Globals.TileSize.Y);
            int leftTile = (int)Math.Floor((float)bounds.Left / Globals.TileSize.X);
            int rightTile = (int)Math.Ceiling((float)bounds.Right / Globals.TileSize.X);

            topTile = MathHelper.Clamp(topTile, 0, Globals.tileMap.GetLayer(1).Columns);
            bottomTile = MathHelper.Clamp(bottomTile, 0, Globals.tileMap.GetLayer(1).Columns);
            leftTile = MathHelper.Clamp(leftTile, 0, Globals.tileMap.GetLayer(1).Rows);
            rightTile = MathHelper.Clamp(rightTile, 0, Globals.tileMap.GetLayer(1).Rows);


            List<Rectangle> result = new List<Rectangle>();

            for (int x = topTile; x <= bottomTile; x++) {
                for (int y = leftTile; y <= rightTile; y++) {
                    if(!Globals.tileMap.GetLayer(1)[x, y].IsEmpty) {
                        result.Add(Globals.SceneRectangles[x, y]);
                    }
                }
            }

            return result;
        }

        public virtual void Draw() {
            _tilemap.Draw(Globals.SpriteBatch, Vector2.Zero, Color.White) ;
        }

        public virtual void DrawDebug() { 
        
        }
    }
}
