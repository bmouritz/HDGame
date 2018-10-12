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
        private Bitmap _type;

        public GameObject(string[] name) {}

        public float ChangeX(float X)
        {
            return Y = X++;
        }

        public float ChangeY(float y)
        {
            return Y = y++;
        }

        public virtual void Draw()
        {
            SwinGame.DrawBitmap(Type, X, Y);
        }

        public Bitmap Type { get => _type; set => _type = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
    }
}
