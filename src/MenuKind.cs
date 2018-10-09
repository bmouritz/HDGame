using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class MenuKind
    {
        private int _x, _y;

        public void Draw(string menu, float X, float Y)
        {
            SwinGame.ProcessEvents();
            SwinGame.DrawBitmap(menu, X, Y);
            SwinGame.RefreshScreen();
        }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
    }
}
