using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.src
{
    public class Score
    {
        private static Score instance;
        private int _score;

        private Score()
        {
            _score = 0;
        }

        private void AddToScore(int howMuch)
        {
            _score = _score + howMuch;
        }

        private void RemoveFromScore(int howMuch)
        {
            _score = _score - howMuch;
        }

        public static Score Instance
        {
            get { if (instance == null) { instance = new Score(); }
                return instance;
            }
        }
    }
}
