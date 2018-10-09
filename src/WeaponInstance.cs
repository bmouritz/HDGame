using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class WeaponInstance : WeaponManager, IDraw
    {
        private float _x, _y;
        private float _laserSpeed;

        public WeaponInstance(float x, float y, string type)
        {
            _x = x;
            _y = y;
            LaserSpeed1 = 30;
        }

        public void ProcessMovement(string type)
        {
            if (X < SwinGame.ScreenWidth())
            {
                X += LaserSpeed1;
                Draw(type);
            }
        }

        public void Draw(string type)
        {
            SwinGame.DrawBitmap(type, X + 155, Y + 33);
            ProcessMovement(type);
        }

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float LaserSpeed1 { get => _laserSpeed; set => _laserSpeed = value; }
    }
}
