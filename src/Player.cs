using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Player : GameObject, IDraw
    {
        private float _xShip, _yShip;
        private float _move;
        GameObject ship = new GameObject(new string[] { "ship" } );
        WeaponManager _weapon = new WeaponManager();

        public Player(string[] name) : base(new string[] { "Player" } )
        {
            _move = 10;
            XShip = 100;
            YShip = 100;
        }

        public void MoveShip()
        {
            WrapObject();
            if (SwinGame.KeyDown(KeyCode.LeftKey))
            {
                XShip -= ship.ChangeX(Move);
            }

            if (SwinGame.KeyDown(KeyCode.RightKey))
            {
                XShip += ship.ChangeX(Move);
            }

            if (SwinGame.KeyDown(KeyCode.UpKey))
            {
                YShip -= ship.ChangeY(Move);
            }

            if (SwinGame.KeyDown(KeyCode.DownKey))
            {
                YShip += ship.ChangeY(Move);
            }
        }

        public void WrapObject()
        {
            if (XShip < -((SwinGame.BitmapWidth(Bitmap))))
            {
                XShip = SwinGame.ScreenWidth();
            }

            else if (this.XShip > SwinGame.ScreenWidth())
            {
                XShip = -SwinGame.BitmapWidth(Bitmap);
            }

            if (this.YShip < (-(SwinGame.BitmapHeight(this.Bitmap))))
            {
                this.YShip = (SwinGame.ScreenHeight());
            }

            else if (this.YShip > SwinGame.ScreenHeight())
            {
                this.YShip = -(SwinGame.BitmapHeight(this.Bitmap));
            }
        }

        public void Shoot(string type)
        {
            Weapon.ShootWeapon(type, XShip, YShip);
        }

        public override void Draw()
        {
            Bitmap = SwinGame.BitmapNamed("ship");
            SwinGame.DrawBitmap(this.Bitmap , XShip, YShip);
        }

        public float Move { get => _move; set => _move = value; }
        public float XShip { get => _xShip; set => _xShip = value; }
        public float YShip { get => _yShip; set => _yShip = value; }
        public WeaponManager Weapon { get => _weapon; set => _weapon = value; }
    }
}
