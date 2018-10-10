using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class EnemyManager
    { 
        private float _xEnemy, _yEnemy;
        List<EnemyInstance> _enemyList = new List<EnemyInstance>();

        public EnemyManager()
        {
            XEnemy = 1280 + (SwinGame.Rnd(SwinGame.ScreenWidth() + 500));
            YEnemy = SwinGame.Rnd(720 - 100);
        }

        public void EnemyStart()
        {
            for (int i = 0; i < 2; i++)
            {
                EnemyList.Add(new EnemyInstance(XEnemy, YEnemy, 10, SwinGame.BitmapNamed("enemy1")));
                EnemyList.Add(new EnemyInstance(XEnemy, YEnemy, 8, SwinGame.BitmapNamed("enemy2")));
                EnemyList.Add(new EnemyInstance(XEnemy, YEnemy, 12, SwinGame.BitmapNamed("enemy3")));
            }
        }

        public void EnemyOffScreen()
        {
            foreach (EnemyInstance enemy in _enemyList)
            {
                if(enemy.X == -100 || enemy.X < -100)
                {
                    enemy.X = 1280 + (SwinGame.Rnd(SwinGame.ScreenWidth() + 500));
                    enemy.Y = SwinGame.Rnd(720 - 100);
                }
            }
        }

        public void Draw()
        {
            foreach (EnemyInstance e in EnemyList)
            {
                e.Draw();
            }
            EnemyOffScreen();
        }

        public List<EnemyInstance> EnemyList { get => _enemyList; set => _enemyList = value; }
        public float XEnemy { get => _xEnemy; set => _xEnemy = value; }
        public float YEnemy { get => _yEnemy; set => _yEnemy = value; }
    }
}