//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SwinGameSDK;

//namespace MyGame.src
//{
//    public class EnemyFactory
//    {
//        private float _xEnemy, _yEnemy;

//        public EnemyFactory()
//        {
//            XEnemy = 1280 + (SwinGame.Rnd(SwinGame.ScreenWidth() + 500));
//            YEnemy = SwinGame.Rnd(720 - 100);
//        }

//        public EnemyFactory GetEnemy(string enemyType)
//        {
//            if (enemyType == "enemy1")
//            {
//                return new EnemySlow(XEnemy, YEnemy);
//            }

//            else if (enemyType == "enemy2")
//            {
//                return new EnemyMedium(XEnemy, YEnemy);
//            }

//            else if (enemyType == "enemy3")
//            {
//                return new EnemyFast(XEnemy, YEnemy);
//            }

//            else return null;
//        }

//        public float XEnemy { get => _xEnemy; set => _xEnemy = value; }
//        public float YEnemy { get => _yEnemy; set => _yEnemy = value; }
//    }
//}
