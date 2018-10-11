﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class EnemyFast : IEnemy
    {
        private float _x, _y;
        private float _speed;
        private Bitmap _type;

        public EnemyFast(float x, float y)
        {
            X = x;
            Y = y;
            _speed = 12;
            Type = SwinGame.BitmapNamed("enemy3");
        }

        public void Move()
        {
            X -= _speed;
            Draw();
        }

        public void Draw()
        {
            SwinGame.DrawBitmap(Type, X, Y);
            Move();
        }

        public Bitmap Type { get => _type; set => _type = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
    }
}
