using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.src
{
    public class GameData
    {
        private static GameData instance;
        private int _score;

        private GameData()
        {
            _score = 0;
        }

        public static GameData Instance
        {
            get { if (instance == null) { instance = new GameData(); }
                return instance;
            }
        }

        public static int Score
        {
            get
            {
                return instance._score;
            }

            set
            {
                instance._score = value;
            }
        }

        private void AddToScore(int AddScore)
        {
            instance._score += AddScore;
        }

        private void DecreaseScore(int AddScore)
        {
            instance._score -= AddScore;
        }
    }
}
