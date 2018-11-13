using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class GameObject
    {
        private float _x, _y;
        private Bitmap _type;

        public GameObject() {}

        /// <summary>
        /// Changes the X value of the GameObjects.
        /// </summary>
        /// <param name="X">a X float.</param>
        /// <returns>new X value</returns>
        public float ChangeX(float X)
        {
            return X = X++;
        }

        /// <summary>
        /// Changes the Y value of the GameObjects.
        /// </summary>
        /// <param name="y">a Y float</param>
        /// <returns>new Y value</returns>
        public float ChangeY(float y)
        {
            return Y = y++;
        }

        public virtual void Draw()
        {
            SwinGame.DrawBitmap(Type, X, Y);
        }

        public Bitmap Type { get => _type; set => _type = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
    }
}
