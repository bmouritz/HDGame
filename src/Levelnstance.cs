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
        public Levelnstance(string name) : base(new string[] { "Level 1" } )
        {
            X = Y = 0;
        }

        public override void Draw()
        {
            SwinGame.DrawBitmap(Image, X, Y);
        }
    }
}
