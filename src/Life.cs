using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Life : GameObject
    {
        private int _health;
        private bool _alive;
        List<GameObject> gameObs = new List<GameObject>();

        public Life() : base(new string[] { "Life" } )
        {
            Alive = true;
            Health = 100;
        }

        //public float GetHealth(GameObject obj)
        //{
        //    foreach (GameObject ship in gameObs)
        //    {
        //        if (ship == obj)
        //        {
        //            return obj.Health();
        //        }
        //        else return 0;
        //    }
        //}
        

        //public int HealthChange(GameObject obj, int health)
        //{
        //    return Health;
        //}

        //public bool IsAlive(GameObject obj)
        //{
        //    foreach (GameObject play in gameObs)
        //    {
        //        if (play.Alive == false)
        //        {
        //            return false;
        //        }
        //        else return true;
        //    }
        //}

        public int Health { get => _health; set => _health = value; }
        public bool Alive { get => _alive; set => _alive = value; }
    }
}
