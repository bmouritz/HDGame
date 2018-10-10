using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class GameObject : IDraw
    {
        private float _x, _y;
        private Bitmap _bitmap;

        public GameObject(string[] name) {}

        public float ChangeX(float X)
        {
            return X = X++;
        }

        public float ChangeY(float y)
        {
            return y = y++;
        }

        public virtual void Draw()
        {
            SwinGame.DrawBitmap(_bitmap, X, Y);
        }

        public Bitmap Bitmap { get => _bitmap; set => _bitmap = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
    }
}
