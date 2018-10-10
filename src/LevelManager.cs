using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public abstract class LevelManager : IDraw
    {
        public LevelManager(string[] name) { }

        public abstract void Draw();
    }
}
