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

        /// <summary>
        /// Processes the amount of shots available.
        /// </summary>
        /// <param name="type">what kind of laser</param>
        /// <param name="X">Float</param>
        /// <param name="Y">Float</param>
        public void ShootWeapon(Bitmap type, float X, float Y)
        {
            if (Shots > 0)
            {
                WeaponList.Add(new WeaponInstance(X, Y, type));
                SwinGame.PlaySoundEffect("Laser");
            }

            if(Shots <= 0)
            {
                SwinGame.PlaySoundEffect("Reload");
            }
        }

        /// <summary>
        /// Removes all lasers from the list if off the screen.
        /// </summary>
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

        /// <summary>
        /// Removes the laser from the list if a collision has occured.
        /// </summary>
        /// <param name="bullet"></param>
        public void RemoveLaserCollision(WeaponInstance bullet)
        {
            _weaponList.Remove(bullet);
        }

        /// <summary>
        /// Draws all instances of the weapons, and calls the method to check if they are offscreen.
        /// </summary>
        public void Draw()
        {
            foreach (WeaponInstance _weapon in WeaponList)
            {
                _weapon.Draw();
            }
            RemoveLaserIfOffScreen();
        }

        /// <summary>
        /// Reloads the laser if out of shots.
        /// </summary>
        public void ReloadLaser()
        {
            _shots += 15;
            SwinGame.PlaySoundEffect("Ammo");
        }

        public List<WeaponInstance> WeaponList { get => _weaponList; set => _weaponList = value; }
        public int Shots { get => _shots; set => _shots = value; }
    }
}
