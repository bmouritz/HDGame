using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class WeaponInstance : IDraw
    {
        private float _x, _y;
        private float _laserSpeed;
        private Bitmap _type;

        public WeaponInstance(float x, float y, Bitmap type)
        {
            X = x;
            Y = y;
            _laserSpeed = 30;
            Type = type;
        }

        public void ProcessMovement()
        {
            X += _laserSpeed;
        }

        public void Draw()
        {
            ProcessMovement();
            SwinGame.DrawBitmap(Type, X + 155, Y + 33);
        }

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public Bitmap Type { get => _type; set => _type = value; }
    }
}
