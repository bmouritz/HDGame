using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    public class Player : GameObject
    {
        private float _x, _y;
        private float _move;
        private bool _laserShot;
        GameObject ship = new GameObject(new string[] { "ship" } );
        List<Laser> _lasers = new List<Laser>();
        List<SpecialLaser> _specialLasers = new List<SpecialLaser>();

        public Player(string[] name) : base(new string[] { "Player" } )
        {
            _move = 10;
            _laserShot = false;
            _x = 100;
            _y = 100;
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

        public void ShootLaser()
        {
            _lasers.Add(new Laser(XShip, YShip));
        }

        public void RemoveLaser()
        {
            foreach (Laser laser in _lasers.ToList())
            {
                if (laser.X > SwinGame.ScreenWidth())
                {
                    _lasers.Remove(laser);
                }
            }

            foreach (SpecialLaser slaser in _specialLasers.ToList())
            {
                if (slaser.X > SwinGame.ScreenWidth())
                {
                    _specialLasers.Remove(slaser);
                }
            }
        }

        public void ProcessLasers()
        {
            foreach (Laser laser in _lasers)
            {
                laser.ProcessMovement();
            }
            RemoveLaser();
        }

        public void ShootSpecialLaser()
        {
            _specialLasers.Add(new SpecialLaser(XShip, YShip));
        }

        public void ProcessSpecialLaser()
        {
            foreach (SpecialLaser slaser in _specialLasers)
            {
                slaser.ProcessMovement();
            }
        }

        public override void Draw()
        {
            SwinGame.DrawBitmap("ship" , XShip, YShip);
            ProcessLasers();
            ProcessSpecialLaser();
        }

        public Laser Laser { get; set; }
        public float XShip { get => _x; set => _x = value; }
        public float YShip { get => _y; set => _y = value; }
        public float Move { get => _move; set => _move = value; }
        public bool LaserShot { get => _laserShot; set => _laserShot = value; }
    }
}
