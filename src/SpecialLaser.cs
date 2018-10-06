using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class SpecialLaser : Weapon
    {
        private float _x, _y;
        private float _laserSpeed;

        public SpecialLaser(float x, float y)
        {
            _x = x;
            _y = y;
            _laserSpeed = 30;
        }

        public override void ProcessMovement()
        {
            if (_x < SwinGame.ScreenWidth())
            {
                _x += LaserSpeed;
                Draw(_x + 115, _y + 33);
            }
        }

        public override void Draw(float X, float Y)
        {
            SwinGame.DrawBitmap("laserSpec", X, Y);
        }

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float LaserSpeed { get => _laserSpeed; }
    }
}
