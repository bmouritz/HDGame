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
        private int _playerHealth;
        private int _currentLevel;

        private GameData()
        {
            Score = 0;
            PlayerHealth = 100;
            CurrentLevel = 1;
        }

        public static GameData Instance
        {
            get
            {
                if (instance == null)
                { instance = new GameData(); }
                return instance;
            }
        }

        public int Score { get => _score; set => _score = value; }
        public int PlayerHealth { get => _playerHealth; set => _playerHealth = value; }
        public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
    }
}
