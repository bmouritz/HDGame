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

        public bool EnemyHitShip(Player p, EnemyInstance e)
        {
            return SwinGame.BitmapCollision(e.Type, e.X, e.Y, p.Type, p.XShip, p.YShip);
        }

        public bool WeaponHitEnemy(WeaponInstance w, EnemyInstance e)
        {
            return SwinGame.BitmapCollision(w.Type, w.X, w.Y, e.Type, e.X, e.Y);
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
                    GameData.Instance.Score -= 3;
                    GameData.Instance.PlayerHealth -= 10;
                    _temp = enemy.Type;
                    e.AddEnemyIfRemoved(_temp);
                }
            }
        }

        public void CheckCollisionWeaponEnemy(WeaponManager w, EnemyManager e)
        {
            List<WeaponInstance> weapons = w.WeaponList;
            List<EnemyInstance> enemies = e.EnemyList;

            foreach (WeaponInstance shot in weapons.ToList())
            {
                foreach (EnemyInstance enemy in enemies.ToList())
                {
                    if (WeaponHitEnemy(shot, enemy))
                    {
                        SwinGame.PlaySoundEffect("Explode");
                        if (shot.Type == SwinGame.BitmapNamed("laser"))
                        {
                            w.RemoveLaserCollision(shot);
                        }
                        enemies.Remove(enemy);
                        GameData.Instance.Score += 1;
                        _temp = enemy.Type;
                        e.AddEnemyIfRemoved(_temp);
                    }
                }
            }
        }
    }
}
