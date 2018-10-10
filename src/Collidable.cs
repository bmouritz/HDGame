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
        public bool EnemyHitShip(Player p, EnemyInstance e)
        {
            return SwinGame.BitmapCollision(e.Type, e.X, e.X, p.Type, p.XShip, p.YShip);
        }

        public bool WeaponHitEnemy(WeaponInstance w, EnemyInstance e)
        {
            return SwinGame.BitmapCollision(e.Type, e.X, e.X, w.Type, w.X, w.Y);
        }

        public void CheckCollisionEnemyPlayer(Player p, EnemyManager e)
        {
            List<EnemyInstance> enemies = e.EnemyList;

            foreach (EnemyInstance enemy in enemies.ToList())
            {
                if (EnemyHitShip(p, enemy))
                {
                    SwinGame.PlaySoundEffect("Explode");
                    enemies.Remove(enemy);
                }
            }
        }

        public void CheckCollisionWeaponEnemy(WeaponManager w, EnemyManager e)
        {
            List<WeaponInstance> weapons = w.WeaponList;
            List<EnemyInstance> enemies = e.EnemyList;

            foreach (WeaponInstance shot in weapons)
            {
                foreach (EnemyInstance enemy in enemies)
                {
                    if (WeaponHitEnemy(shot, enemy))
                    {
                        SwinGame.PlaySoundEffect("Explode");
                    }
                }
            }
        }
    }
}
