using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class EnemyMedium : EnemyBase, IEnemy
    {
        public EnemyMedium(float x, float y)
        {
            X = x;
            Y = y;
            Speed = 8;
            Type = SwinGame.BitmapNamed("enemy2");
        }
    }
}
