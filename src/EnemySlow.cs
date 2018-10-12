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
        private Player _player;

        public EnemySlow(float x, float y, Player player)
        {
            X = x;
            Y = y;
            _player = player;
            _speed = 5;
            Type = SwinGame.BitmapNamed("enemy1");
        }

        public void Move()
        {
            Vector location = new Vector() { X = _x, Y = _y };
            Vector playerPos = new Vector() { X = _player.XShip, Y = _player.YShip };
            Vector velocity = playerPos.SubtractVector(location).UnitVector.Multiply(_speed);
            _x += velocity.X;
            _y += velocity.Y;
            _x -= _speed * 1.4f;
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
