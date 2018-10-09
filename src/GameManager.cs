using System;
using System.Collections.Generic;
using SwinGameSDK;
using MyGame.src;

namespace MyGame.src
{
    public class GameManager
    {
        private bool _active;
        private string _shotType;
        Player _player = new Player(new string[] { "player" } );
        EnemyManager _enemy = new EnemyManager();   

        public GameManager()
        {
            LoadResources();
            SwinGame.OpenGraphicsWindow("Space Wars", 1280, 720);
            SwinGame.DrawBitmap("background", 0, 0);
            SwinGame.PlayMusic("Limits");
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

        public void Render()
        {
            SwinGame.ProcessEvents();

            //Draws the background and all required information in the level.
            SwinGame.DrawBitmap("background", 0, 0);
            SwinGame.FillRectangle(Color.Black, 0, 0, 1280, 50);
            SwinGame.DrawBitmap("spacewars", 0, 0);
            SwinGame.DrawText("Score: ", Color.White, 1140, 15);
            SwinGame.DrawText("Health: ", Color.White, 1140, 35);
            SwinGame.DrawText("Level: ", Color.White, 1040, 35);


            _player.Draw();
            _enemy.EnemyStart();

            SwinGame.RefreshScreen();
        }

        public void Update()
        {
            _player.MoveShip();

            if (SwinGame.KeyTyped(KeyCode.SpaceKey))
            {
                _shotType = "laser";
                _player.Shoot(_shotType);
                SwinGame.RefreshScreen();
                SwinGame.ClearScreen();
                SwinGame.DrawBitmap("background", 0, 0);
            }

            if (SwinGame.KeyTyped(KeyCode.SKey))
            {
                _shotType = "laserSpec";
                _player.Shoot(_shotType);
                SwinGame.RefreshScreen();
                SwinGame.ClearScreen();
                SwinGame.DrawBitmap("background", 0, 0);
            }
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
            SwinGame.LoadMusicNamed("Laser", "laser.wav");
            SwinGame.LoadMusicNamed("Explode", "Explosion.wav");
        }

        public bool Active { get => _active; set => _active = value; }
    }
}