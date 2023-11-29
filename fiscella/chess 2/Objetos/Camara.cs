using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2.Objetos
{
    internal class Camara
    {
        private readonly Vector2 _origin;

        private readonly float MinZoom = 0.1f;

        public Vector2 position;
        public float zoom = 1.5f;
        public Rectangle? limits;

        public Camara() {
            _origin = new Vector2(Globals.Viewport.Width / 2, Globals.Viewport.Height / 2);
        }

        public Vector2 Position
        {
            get {
                return position;
            }
            set { 
                position = value;
                ValidatePosition();
            }
        }

        public float Zoom {
            get {
                return zoom;
            }
            set
            {
                zoom = MathHelper.Max(value, MinZoom);
                ValidateZoom();
                ValidatePosition();
            }
        }

        public Matrix ViewMatrix { 
            get { 
                return Matrix.CreateTranslation(new Vector3(-position, 0f)) *
                       Matrix.CreateTranslation(new Vector3(-_origin, 0f)) *
                       Matrix.CreateScale(zoom, zoom, 1f) *
                       Matrix.CreateTranslation(new Vector3(_origin, 0f));
            }
        }

        private void ValidateZoom() {
            if (limits.HasValue) { 
                float minZoomX = (float)Globals.Viewport.Width / limits.Value.Width;
                float minZoomY = (float)Globals.Viewport.Height / limits.Value.Height;
                zoom = MathHelper.Max(zoom, MathHelper.Max(minZoomY, minZoomX));
            }
        }

        private void ValidatePosition()
        {
            if (limits.HasValue) {
                Vector2 cameraWorldMin = Vector2.Transform(Vector2.Zero, Matrix.Invert(ViewMatrix));
                Vector2 cameraSize = new Vector2(Globals.Viewport.Width, Globals.Viewport.Height) / zoom;
                Vector2 limitWorldMin = new Vector2(limits.Value.Left, limits.Value.Top);
                Vector2 limitWorldMax = new Vector2(limits.Value.Right, limits.Value.Bottom);
                Vector2 positionOffset = position - cameraWorldMin;
                position = Vector2.Clamp(cameraWorldMin, limitWorldMin, limitWorldMax - cameraSize) + positionOffset;
            }
        }

        public void Update(Prota _protagonista) {

            Position = _protagonista.Position - new Vector2(Globals.Viewport.Width / 2, Globals.Viewport.Height / 2);

            Globals.viewMatrix = ViewMatrix;
        }
    }
}
