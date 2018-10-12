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
        private Player _player;

        public EnemyInstance(float x, float y, float move, Bitmap type, Player player)
        {
            _player = player;
            _move = move;
            X = x;
            Y = y;
            Type = type;
        }

        public void MoveEnemy()
        {
            if (Type == SwinGame.BitmapNamed("enemy1"))
            {
                
                Vector location = new Vector() { X = _x, Y = _y };
                Vector playerPos = new Vector() { X = _player.XShip, Y = _player.YShip };
                Vector velocity = playerPos.SubtractVector(location).UnitVector.Multiply(_move);
                _x += velocity.X;
                _y += velocity.Y;
                _x -= _move * 1.4f;
            }
            else
            {
                X -= _move;
            }
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