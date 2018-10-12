using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class WeaponManager
    {
        List<WeaponInstance> _weaponList = new List<WeaponInstance>();
        private int _shots;

        public WeaponManager()
        {
            _shots = 15;
        }

        public void ShootWeapon(Bitmap type, float X, float Y)
        {
            if (Shots > 0)
            {
                WeaponList.Add(new WeaponInstance(X, Y, type));
                SwinGame.PlaySoundEffect("Laser");
            }
        }

        public void RemoveLaserIfOffScreen()
        {
            foreach (WeaponInstance weapon in WeaponList.ToList())
            {
                if (weapon.X > SwinGame.ScreenWidth())
                {
                    WeaponList.Remove(weapon);
                }
            }
        }

        public void RemoveLaserCollision(WeaponInstance bullet)
        {
            _weaponList.Remove(bullet);
        }

        public void Draw()
        {
            foreach (WeaponInstance _weapon in WeaponList)
            {
                _weapon.Draw();
            }
            RemoveLaserIfOffScreen();
        }

        public void ReloadLaser()
        {
            _shots = 15;
        }

        public List<WeaponInstance> WeaponList { get => _weaponList; set => _weaponList = value; }
        public int Shots { get => _shots; set => _shots = value; }
    }
}
