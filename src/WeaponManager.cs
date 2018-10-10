using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class WeaponManager : GameObject
    {
        List<WeaponInstance> _weaponList = new List<WeaponInstance>();

        public WeaponManager() : base(new string[] { "Weapon" }) { }

        public void ShootWeapon(string type, float X, float Y)
        {
            WeaponList.Add(new WeaponInstance(X, Y, type));
            SwinGame.PlaySoundEffect("Laser");
            foreach (WeaponInstance _weapon in WeaponList)
            {
                _weapon.Draw(type);
            }
        }

        public void RemoveLaser()
        {
            foreach (WeaponInstance weapon in WeaponList.ToList())
            {
                if (weapon.X > SwinGame.ScreenWidth())
                {
                    WeaponList.Remove(weapon);
                }
            }
        }
        public List<WeaponInstance> WeaponList { get => _weaponList; set => _weaponList = value; }
    }
}
