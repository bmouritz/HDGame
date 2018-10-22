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
        Player _player;

        public EnemyFactory(Player player)
        {
            RandomCoords();
            _player = player;
        }

        /// <summary>
        /// Gets the SlowEnemy type
        /// </summary>
        /// <returns>A new SlowEnemy object if called.</returns>
        public IEnemy GetSlowEnemy()
        {
            RandomCoords();
            return new EnemySlow(XEnemy, YEnemy, _player);
        }

        /// <summary>
        /// Gets the MediumEnemy type
        /// </summary>
        /// <returns>A new MediumEnemy object if called.</returns>
        public IEnemy GetMediumEnemy()
        {
            RandomCoords();
            return new EnemyMedium(XEnemy, YEnemy);
        }

        /// <summary>
        /// Gets the FastEnemy type
        /// </summary>
        /// <returns>A new FastEnemy object if called.</returns>
        public IEnemy GetFastEnemy()
        {
            RandomCoords();
            return new EnemyFast(XEnemy, YEnemy);
        }

        /// <summary>
        /// This is a set of X & Y coords to setup all enemies off the screen randomly.
        /// </summary>
        public void RandomCoords()
        {
            _xEnemy = 1280 + (SwinGame.Rnd(SwinGame.ScreenWidth() + 500));
            _yEnemy = SwinGame.Rnd(720 - 100);
        }

        public float XEnemy { get => _xEnemy; }
        public float YEnemy { get => _yEnemy; }
    }
}
