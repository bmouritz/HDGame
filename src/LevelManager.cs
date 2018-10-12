using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class LevelManager
    {
        private int _x, _y;
        private Bitmap _type;

        public LevelManager() { }

        public void Draw() { }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public Bitmap Type { get => _type; set => _type = value; }
    }
}
