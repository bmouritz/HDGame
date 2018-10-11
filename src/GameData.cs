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
        }

        public static GameData Instance
        {
            get { if (instance == null) { instance = new GameData(); }
                return instance;
            }
        }

        public static int Score { get => instance._score; set => instance._score = value; }
    }
}
