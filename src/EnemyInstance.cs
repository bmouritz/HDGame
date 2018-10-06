using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
namespace MyGame.src
{
    public class EnemyInstance : EnemyManager
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

        public override void MoveEnemy()
        {
            X -= MoveE;
            Draw();
        }

        public override void Draw()
        {
            SwinGame.DrawBitmap(this.Type, X, Y);
        }

        public float MoveE { get => _move; set => _move = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public string Type { get => _type; set => _type = value; }
    }
}