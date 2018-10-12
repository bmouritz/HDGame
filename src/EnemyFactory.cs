using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class EnemyFactory
    {
        private float _xEnemy, _yEnemy;
        private Bitmap _type;
        Player _player;

        public EnemyFactory(float X, float Y, Player player)
        {
            XEnemy = X;
            YEnemy = Y;
            _player = player;
        }

        public IEnemy GetSlowEnemy()
        {
            Type = SwinGame.BitmapNamed("enemy1");
            return new EnemySlow(XEnemy, YEnemy, _player);
        }

        public IEnemy GetMediumEnemy()
        {
            Type = SwinGame.BitmapNamed("enemy2");
            return new EnemyMedium(XEnemy, YEnemy);
        }

        public IEnemy GetFastEnemy()
        {
            Type = SwinGame.BitmapNamed("enemy3");
            return new EnemyFast(XEnemy, YEnemy);
        }

        public float XEnemy { get => _xEnemy; set => _xEnemy = value; }
        public float YEnemy { get => _yEnemy; set => _yEnemy = value; }
        public Bitmap Type { get => _type; set => _type = value; }
    }
}
