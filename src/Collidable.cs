using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Collidable
    {
        private Bitmap _temp;

        /// <summary>
        /// This checks to see if any individual enemy and the player have collided.
        /// </summary>
        /// <param name="p">Is the player</param>
        /// <param name="e">Is the enemy, taken from a list of enemies.</param>
        /// <returns>True if the collision has occured</returns>
        public bool EnemyHitShip(Player p, IEnemy e)
        {
            return SwinGame.BitmapCollision(e.Type, e.X, e.Y, p.Type, p.XShip, p.YShip);
        }

        /// <summary>
        /// This checks if any of the laser shots have collided with an enemy.
        /// </summary>
        /// <param name="w">Is a single instance of a laser shot</param>
        /// <param name="e">Is a single instance of an enemy</param>
        /// <returns>True if the two object collide.</returns>
        public bool WeaponHitEnemy(WeaponInstance w, IEnemy e)
        {
            return SwinGame.BitmapCollision(w.Type, w.X, w.Y, e.Type, e.X, e.Y);
        }

        /// <summary>
        /// This runs via GameManger, through the game loop to iterate through all enemies and call the collision check.
        /// </summary>
        /// <param name="p">Is the player</param>
        /// <param name="e">Is the list of enemies to iterate through</param>
        public void CheckCollisionEnemyPlayer(Player p, EnemyManager e)
        {
            List<IEnemy> enemies = e.EnemyList;

            foreach (IEnemy enemy in enemies.ToList())
            {
                if (EnemyHitShip(p, enemy))
                {
                    SwinGame.PlaySoundEffect("Explode");
                    SwinGame.DrawBitmap("explode", p.X, p.Y);
                    enemies.Remove(enemy);
                    GameData.Instance.Score -= 3;
                    GameData.Instance.PlayerHealth -= 10;
                    _temp = enemy.Type;
                    e.AddEnemyIfRemoved(_temp);
                }
            }
        }

        /// <summary>
        /// This runs via GameManager, through the game loop to iterate through enemy and laser lists and calls the collision check.
        /// </summary>
        /// <param name="w">Is a list of all laser shots.</param>
        /// <param name="e">Is a list of all enemies.</param>
        public void CheckCollisionWeaponEnemy(WeaponManager w, EnemyManager e)
        {
            List<WeaponInstance> weapons = w.WeaponList;
            List<IEnemy> enemies = e.EnemyList;

            foreach (WeaponInstance shot in weapons.ToList())
            {
                foreach (IEnemy enemy in enemies.ToList())
                {
                    if (WeaponHitEnemy(shot, enemy))
                    {
                        SwinGame.PlaySoundEffect("Explode");
                        if (shot.Type == SwinGame.BitmapNamed("laser"))
                        {
                            w.RemoveLaserCollision(shot);
                        }
                        enemies.Remove(enemy);
                        SwinGame.DrawBitmap("explode", enemy.X, enemy.Y);
                        GameData.Instance.Score += 1;
                        _temp = enemy.Type;
                        e.AddEnemyIfRemoved(_temp);
                    }
                }
            }
        }
    }
}
