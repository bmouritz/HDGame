using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Laser : Weapon
    {
        private float _x, _y;
        private float _laserSpeed;

        public Laser(float x, float y)
        {
            _x = x;
            _y = y;
            _laserSpeed = 30;
        }

        public override void ProcessMovement()
        {
            SwinGame.PlaySoundEffect("Laser");
            if (X < SwinGame.ScreenWidth())
            {
                X += LaserSpeed;
                Draw(X + 115, Y + 33);
            }
        }

        public override void Draw(float X, float Y)
        {
            SwinGame.DrawBitmap("laser", X, Y);
        }

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float LaserSpeed { get => _laserSpeed; }
    }
}
