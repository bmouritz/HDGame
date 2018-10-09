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
        private float _x, _y;
        private float _move;
        private bool _hasCollided;
        GameObject ship = new GameObject(new string[] { "ship" } );
        WeaponManager _weapon = new WeaponManager();

        public Player(string[] name) : base(new string[] { "Player" } )
        {
            _move = 10;
            _x = 100;
            _y = 100;
            _hasCollided = false;
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
            if (this.XShip < -((SwinGame.BitmapWidth(this.Bitmap))))
            {
                this.XShip = SwinGame.ScreenWidth();
            }

            else if (this.XShip > SwinGame.ScreenWidth())
            {
                this.XShip = -SwinGame.BitmapWidth(this.Bitmap);
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

        //public bool Collided()
        //{
        //    return false;
        //}

        public void Shoot(string type)
        {
            _weapon.ShootWeapon(type, XShip, YShip);
        }

        public override void Draw()
        {
            SwinGame.DrawBitmap("ship" , XShip, YShip);
        }

        public float XShip { get => _x; set => _x = value; }
        public float YShip { get => _y; set => _y = value; }
        public float Move { get => _move; set => _move = value; }
        public bool HasCollided { get => _hasCollided; set => _hasCollided = value; }
    }
}
