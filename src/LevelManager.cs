using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public abstract class LevelManager : IDraw
    {
        private int _x, _y;
        private Bitmap _image;

        public LevelManager(string[] name) { }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public Bitmap Image { get => _image; set => _image = value; }

        public abstract void Draw();
    }
}
