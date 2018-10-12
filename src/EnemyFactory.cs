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
        List<IEnemy> _enemyList = new List<IEnemy>();

        public EnemyFactory(float X, float Y)
        {
            XEnemy = X;
            YEnemy = Y;
        }

        public IEnemy GetSlowEnemy()
        {
            Type = SwinGame.BitmapNamed("enemy1");
            EnemyList.Add(new EnemySlow(XEnemy, YEnemy));
            return new EnemySlow(XEnemy, YEnemy);
        }

        public IEnemy GetMediumEnemy()
        {
            Type = SwinGame.BitmapNamed("enemy2");
            EnemyList.Add(new EnemyMedium(XEnemy, YEnemy));
            return new EnemyMedium(XEnemy, YEnemy);
        }

        public IEnemy GetFastEnemy()
        {
            Type = SwinGame.BitmapNamed("enemy3");
            EnemyList.Add(new EnemyFast(XEnemy, YEnemy));
            return new EnemyFast(XEnemy, YEnemy);
        }

        public void AddEnemyIfRemoved(Bitmap DestroyedEnemy)
        {
            if (DestroyedEnemy == SwinGame.BitmapNamed("enemy1"))
            {
                EnemyList.Add(new EnemySlow(XEnemy, YEnemy));
            }

            else if (DestroyedEnemy == SwinGame.BitmapNamed("enemy2"))
            {
                EnemyList.Add(new EnemyMedium(XEnemy, YEnemy));
            }

            else if (DestroyedEnemy == SwinGame.BitmapNamed("enemy3"))
            {
                EnemyList.Add(new EnemyFast(XEnemy, YEnemy));
            }
        }

        public void Draw()
        {
            foreach (IEnemy e in EnemyList)
            {
                e.Draw();
            }
        }

        public float XEnemy { get => _xEnemy; set => _xEnemy = value; }
        public float YEnemy { get => _yEnemy; set => _yEnemy = value; }
        public Bitmap Type { get => _type; set => _type = value; }
        public List<IEnemy> EnemyList { get => _enemyList; set => _enemyList = value; }
    }
}
