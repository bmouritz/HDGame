using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Levelnstance : LevelManager, IDraw
    {
        private float _x, _y;

        public Levelnstance(string name) : base(new string[] { "Level 1" } )
        {
            X = Y = 0;
        }

        public override void Draw()
        {
            SwinGame.DrawBitmap(Image, X, Y);
        }

        public float Y { get => _y; set => _y = value; }
        public float X { get => _x; set => _x = value; }
    }
}
