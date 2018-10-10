using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
namespace MyGame.src
{
    public class EnemyInstance : EnemyManager, IDraw
    {
        private float _x, _y;
        private float _move;
        private string _type;

        public EnemyInstance(float x, float y, float move, string type)
        {
            _move = move;
            _x = x;
            _y = y;
            _type = type;
        }

        public void MoveEnemy()
        {
            X -= _move;
        }

        public override void Draw()
        {
            MoveEnemy();
            SwinGame.DrawBitmap(this._type, X, Y);
        }
    }
}