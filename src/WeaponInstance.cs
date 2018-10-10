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
        private string _type;

        public WeaponInstance(float x, float y, string type)
        {
            _x = x;
            _y = y;
            _laserSpeed = 30;
            _type = type;
        }

        public void ProcessMovement(string type)
        {
            if (this._x < SwinGame.ScreenWidth())
            {
                this._x += _laserSpeed;
                Draw(type);
            }
        }

        public void Draw(string type)
        {
            SwinGame.DrawBitmap(type, this._x + 155, this._y + 33);
            ProcessMovement(type);
        }
    }
}
