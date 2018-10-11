using System;
using System.Collections.Generic;
using SwinGameSDK;
using MyGame.src;

namespace MyGame.src
{
    public class GameManager
    {
        private bool _active;
        private Bitmap _shotType;
        Player _player = new Player(new string[] { "player" } );
        EnemyManager _enemy = new EnemyManager();
        Collidable _collision = new Collidable();

        public GameManager()
        {
            LoadResources();
            SwinGame.OpenGraphicsWindow("Space Wars", 1280, 720);
            SwinGame.DrawBitmap("background", 0, 0);
            SwinGame.PlayMusic("Limits");
      //      GameData.Score = 0;
            Active = true;
        }

        public bool GameRunning()
        {
            if (SwinGame.WindowCloseRequested())
            {
                Active = false;
            }
            return Active;
        }

        public void InitiateEnemies()
        {
            _enemy.EnemyStart();
        }

        public void Render()
        {
            SwinGame.ProcessEvents();

            DrawGameDetails();           

            _player.Draw();
            _player.Weapon.Draw();
            _enemy.Draw();

            SwinGame.RefreshScreen();
        }

        public void Update()
        {
            _player.MoveShip();

            _collision.CheckCollisionEnemyPlayer(_player, _enemy);
            _collision.CheckCollisionWeaponEnemy(_player.Weapon, _enemy);

            if (SwinGame.KeyTyped(KeyCode.SpaceKey))
            {
                _shotType = SwinGame.BitmapNamed("laser");
                _player.Shoot(_shotType);
                SwinGame.RefreshScreen();
            }

            if (SwinGame.KeyTyped(KeyCode.SKey))
            {
                _shotType = SwinGame.BitmapNamed("laserSpec");
                _player.Shoot(_shotType);
                SwinGame.RefreshScreen();
            }
        }

        //Draws the background and all required information in the level.
        public void DrawGameDetails()
        {
            SwinGame.DrawBitmap("background", 0, 0);
            SwinGame.FillRectangle(Color.Black, 0, 0, 1280, 50);
            SwinGame.DrawBitmap("spacewars", 0, 0);
            SwinGame.DrawText("Score: ", Color.White, 1140, 15);
            SwinGame.DrawText("Health: ", Color.White, 1140, 35);
            SwinGame.DrawText("Level: ", Color.White, 1040, 35);
            SwinGame.DrawText("SPECIAL WEAPON CHARGING...", Color.Red, 500, 35);
        //    SwinGame.DrawText((GameData.Score.ToString()), Color.White, 1200, 15);
        }


        public void LoadResources()
        {
            SwinGame.LoadBitmapNamed("background", "background.png");
            SwinGame.LoadBitmapNamed("spacewars", "spacewars.png");
            SwinGame.LoadBitmapNamed("ship", "ship.png");
            SwinGame.LoadBitmapNamed("laser", "lazer.png");
            SwinGame.LoadBitmapNamed("laserSpec", "hecticlazer.png");
            SwinGame.LoadBitmapNamed("enemy1", "enemy1.png");
            SwinGame.LoadBitmapNamed("enemy2", "enemy2.png");
            SwinGame.LoadBitmapNamed("enemy3", "FinalBoss.png");

            SwinGame.LoadMusicNamed("Limits", "Limits.wav");
            SwinGame.LoadSoundEffectNamed("Laser", "laser.wav");
            SwinGame.LoadSoundEffectNamed("Explode", "Explosion.wav");

            _player.Type = SwinGame.BitmapNamed("ship");
        }

        public bool Active { get => _active; set => _active = value; }
    }
}