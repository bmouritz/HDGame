using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Levelnstance : IDraw
    {
        private int _x, _y;
        private Bitmap _type;

        public Levelnstance()
        {
            X = Y = 0;
        }

        public Bitmap Type { get => _type; set => _type = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public void Draw()
        {
            SwinGame.DrawBitmap(Type, X, Y);
        }
    }
}
