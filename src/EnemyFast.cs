using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class EnemyFast : EnemyBase, IEnemy
    {
        public EnemyFast(float x, float y)
        {
            X = x;
            Y = y;
            Speed = 12;
            Type = SwinGame.BitmapNamed("enemy3");
        }
    }
}
