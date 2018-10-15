using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class EnemySlow : EnemyBase, IEnemy
    {
        private float _x, _y;
        private float _speed;
        private Bitmap _type;
        private Player _player;

        public EnemySlow(float x, float y, Player player) : base(x, y)
        {
            this.X = x;
            this.Y = y;
            _player = player;
            _speed = 5;
            this.Type = SwinGame.BitmapNamed("enemy1");
        }

        public override void Move()
        {
            Vector location = new Vector() { X = _x, Y = _y };
            Vector playerPos = new Vector() { X = _player.XShip, Y = _player.YShip };
            Vector velocity = playerPos.SubtractVector(location).UnitVector.Multiply(_speed);
            _x += velocity.X;
            _y += velocity.Y;
            _x -= _speed * 1.4f;
        }
    }
}
