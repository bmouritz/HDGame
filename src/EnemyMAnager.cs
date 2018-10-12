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
        EnemyFactory enemyFactory;
        private Player _player;

        public EnemyManager(Player player)
        {
            XEnemy = 1280 + (SwinGame.Rnd(SwinGame.ScreenWidth() + 500));
            YEnemy = SwinGame.Rnd(720 - 100);
            _player = player;
            enemyFactory = new EnemyFactory(XEnemy, YEnemy);
    }

        public void EnemyStart()
        {
            for (int i = 0; i < 2; i++)
            {
                enemyFactory.GetFastEnemy();
                enemyFactory.GetMediumEnemy();
                enemyFactory.GetSlowEnemy();
            }
        }

        public void EnemyOffScreen()
        {
            foreach (EnemyFactory enemy in enemyFactory.EnemyList)
            {
                if(enemy.XEnemy == -100 || enemy.XEnemy < -100)
                {
                    enemy.XEnemy = 1280 + (SwinGame.Rnd(SwinGame.ScreenWidth() + 500));
                    enemy.YEnemy = SwinGame.Rnd(720 - 100);
                }
            }
        }

        public void Draw()
        {
            enemyFactory.Draw();
        }

        public float XEnemy { get => _xEnemy; set => _xEnemy = value; }
        public float YEnemy { get => _yEnemy; set => _yEnemy = value; }
    }
}