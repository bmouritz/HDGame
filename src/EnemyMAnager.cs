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
        private Player _player;
        EnemyFactory _enemyFactory;
        List<IEnemy> _enemyList = new List<IEnemy>();

        public EnemyManager(Player player)
        {
            _player = player;
            _enemyFactory = new EnemyFactory(_player);
        }

        /// <summary>
        /// Adds enemies to a list.
        /// </summary>
        public void EnemyStart()
        {
            for (int i = 0; i < 2; i++)
            {
                EnemyList.Add(_enemyFactory.GetSlowEnemy());
                EnemyList.Add(_enemyFactory.GetMediumEnemy());
                EnemyList.Add(_enemyFactory.GetFastEnemy());
            }
        }

        /// <summary>
        /// Checks if any enemies are off screen, if so, reset them to the right of the screen randomly.
        /// </summary>
        public void EnemyOffScreen()
        {
            foreach (IEnemy enemy in EnemyList)
            {
                if(enemy.X < -100)
                {
                    enemy.X = 1280 + (SwinGame.Rnd(SwinGame.ScreenWidth() + 500));
                    enemy.Y = SwinGame.Rnd(720 - 100);
                }
            }
        }

        /// <summary>
        /// Adds a new enemy of the same type if destroyed by a collision.
        /// </summary>
        /// <param name="DestroyedEnemy">The type of enemy that was destroy.</param>
        public void AddEnemyIfRemoved(Bitmap DestroyedEnemy)
        {
            if (DestroyedEnemy == SwinGame.BitmapNamed("enemy1"))
            {
                EnemyList.Add(_enemyFactory.GetSlowEnemy());
            }

            else if (DestroyedEnemy == SwinGame.BitmapNamed("enemy2"))
            {
                EnemyList.Add(_enemyFactory.GetMediumEnemy());
            }

            else if (DestroyedEnemy == SwinGame.BitmapNamed("enemy3"))
            {
                EnemyList.Add(_enemyFactory.GetFastEnemy());
            }
        }

        /// <summary>
        /// All current enemies in the list, Draw them and check if they're off the screen.
        /// </summary>
        public void Draw()
        {
            foreach (IEnemy e in EnemyList)
            {
                e.Draw();
            }
            EnemyOffScreen();
        }

        public float XEnemy { get => _xEnemy; set => _xEnemy = value; }
        public float YEnemy { get => _yEnemy; set => _yEnemy = value; }
        public List<IEnemy> EnemyList { get => _enemyList; set => _enemyList = value; }
    }
}