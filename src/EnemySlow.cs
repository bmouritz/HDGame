using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class EnemySlow : EnemyBase, IEnemy
    {
        private Player _player;

        public EnemySlow(float x, float y, Player player)
        {
            X = x;
            Y = y;
            _player = player;
            Speed = 5;
            Type = SwinGame.BitmapNamed("enemy1");
        }

        /// <summary>
        /// This creates a vector between player and enemy, to attract the enemy to the player.
        /// </summary>
        public override void Move()
        {
            Vector _location = new Vector() { X = X, Y = Y };
            Vector _playerPos = new Vector() { X = _player.XShip, Y = _player.YShip };
            Vector _velocity = _playerPos.SubtractVector(_location).UnitVector.Multiply(Speed);
            X += _velocity.X;
            Y += _velocity.Y;
            X -= Speed * 1.4f;
        }
    }
}
