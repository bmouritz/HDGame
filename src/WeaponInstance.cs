using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class WeaponInstance
    {
        private float _x, _y;
        private float _laserSpeed;
        private string _type;

        public float X { get => _x; set => _x = value; }

        public WeaponInstance(float x, float y, string type)
        {
            X = x;
            _y = y;
            _laserSpeed = 30;
            _type = type;
        }

        public void ProcessMovement(string type)
        {
            if (this.X < SwinGame.ScreenWidth())
            {
                this.X += _laserSpeed;
                Draw(type);
            }
        }

        public void Draw(string type)
        {
            SwinGame.DrawBitmap(type, this.X + 155, this._y + 33);
        }
    }
}
