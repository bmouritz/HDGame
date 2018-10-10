using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
namespace MyGame.src
{
    public class EnemyInstance : IDraw
    {
        private float _x, _y;
        private float _move;
        private Bitmap _type;

        public EnemyInstance(float x, float y, float move, Bitmap type)
        {
            _move = move;
            X = x;
            Y = y;
            Type = type;
        }

        public void MoveEnemy()
        {
            X -= _move;
        }

        public void Draw()
        {
            MoveEnemy();
            SwinGame.DrawBitmap(this.Type, X, Y);
        }

        public Bitmap Type { get => _type; set => _type = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
    }
}