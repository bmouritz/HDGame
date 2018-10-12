using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class EnemyMedium : IEnemy
    {
        private float _x, _y;
        private float _speed;
        private Bitmap _type;

        public EnemyMedium(float x, float y)
        {
            X = x;
            Y = y;
            _speed = 8;
            Type = SwinGame.BitmapNamed("enemy2");
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
