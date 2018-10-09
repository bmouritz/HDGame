using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class EnemyManager : GameObject, IDraw
    {
        private float _x, _y;
        private float _move;
        List<EnemyInstance> _enemyList = new List<EnemyInstance>();
        Random _random = new Random();

        public EnemyManager() : base(new string[] { "enemy class" })
        {
        }

        public void EnemyStart()
        {
            _x = (1280 + _random.Next(1280 + 150));
            _y = _random.Next(720 - 100);

            _enemyList.Add(new EnemyInstance(_x, _y, 10, "enemy1"));
            _enemyList.Add(new EnemyInstance(_x, _y, 8, "enemy2"));
            Draw();
        }

        public override void Draw()
        {
            EnemyStart();
            foreach (EnemyInstance e in _enemyList)
            {
                e.Draw();
            }
        }

        public float X1 { get => _x; set => _x = value; }
        public float Y1 { get => _y; set => _y = value; }
        public float Move { get => _move; set => _move = value; }
    }
}