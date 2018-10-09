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
        private float _x, _y;
        private float _laserSpeed;
        List<WeaponInstance> _weaponList = new List<WeaponInstance>();

        public WeaponManager() : base(new string[] { "Weapon" }) { }

        public void ShootWeapon(string type, float X, float Y)
        {
            _weaponList.Add(new WeaponInstance(X, Y, type));

            foreach (WeaponInstance _weapon in _weaponList)
            {
                _weapon.Draw(type);
            }
        }

        public void RemoveLaser()
        {
            foreach (WeaponInstance weapon in _weaponList.ToList())
            {
                if (weapon.X > SwinGame.ScreenWidth())
                {
                    _weaponList.Remove(weapon);
                }
            }
        }

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float LaserSpeed { get => _laserSpeed; set => _laserSpeed = value; }
    }
}
