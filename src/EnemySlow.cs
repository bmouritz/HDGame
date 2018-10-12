using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class EnemySlow : IEnemy
    {
        private float _x, _y;
        private float _speed;
        private Bitmap _type;

        public EnemySlow(float x, float y)
        {
            X = x;
            Y = y;
            _speed = 10;
            Type = SwinGame.BitmapNamed("enemy1");
        }

        public void Move()
        {
            X -= _speed;
        }

        public void Draw()
        {
            SwinGame.DrawBitmap(Type, X, Y);
            Move();
        }

        public Bitmap Type { get => _type; set => _type = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
    }
}
