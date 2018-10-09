using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public abstract class Levels : IDraw
    {
        private Bitmap _image;
        private int _x, _y;

        public Levels(string[] name) { }

        public abstract void Draw();

        public Bitmap Image { get => _image; set => _image = value; }
        public int Y { get => _y; set => _y = value; }
        public int X { get => _x; set => _x = value; }
    }
}
