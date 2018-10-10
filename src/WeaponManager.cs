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

        public WeaponManager() { }

        public void ShootWeapon(Bitmap type, float X, float Y)
        {
            WeaponList.Add(new WeaponInstance(X, Y, type));
            SwinGame.PlaySoundEffect("Laser");
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

        public List<WeaponInstance> WeaponList { get => _weaponList; set => _weaponList = value; }
    }
}
