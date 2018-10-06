using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public abstract class Weapon : GameObject
    {
        private float _x, _y;

        public Weapon() : base(new string[] { "Weapon" }) { }

        public abstract void ProcessMovement();

        public abstract void Draw(float X, float Y);

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
    }
}
