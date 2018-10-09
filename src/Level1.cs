using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Level1 : Levels, IDraw
    {
        private string _image;
        private float _x, _y;

        public Level1(string name) : base(new string[] { "Level 1" } )
        {
            X = Y = 0;
        }

        public override void Draw()
        {
            SwinGame.DrawBitmap(Image, X, Y);
        }

        public string Image1 { get => _image; set => _image = "background"; }
        public float Y { get => _y; set => _y = value; }
        public float X { get => _x; set => _x = value; }
    }
}
