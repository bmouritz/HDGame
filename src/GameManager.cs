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
        EnemyManager _enemyManager;
        Collidable _collision = new Collidable();

        public GameManager()
        {
            _enemyManager = new EnemyManager(_player);
            LoadResources();
            SwinGame.OpenGraphicsWindow("Space Wars", 1280, 720);
            SwinGame.DrawBitmap("background", 0, 0);
            Active = true;
        }

        /// <summary>
        /// Checks if the game is running.
        /// </summary>
        /// <returns>False if windowclose is requested by user.</returns>
        public bool GameRunning()
        {
            if (SwinGame.WindowCloseRequested())
            {
                Active = false;
            }
            return Active;
        }

        /// <summary>
        /// This starts the enemies when the game starts.
        /// </summary>
        public void InitiateEnemies()
        {
            _enemyManager.EnemyStart();
        }

        /// <summary>
        /// Renders all objects in the game.
        /// </summary>
        public void Render()
        {
            SwinGame.ProcessEvents();

            DrawGameDetails();           

            _player.Draw();
            _player.Weapon.Draw();
            _enemyManager.Draw();

            SwinGame.RefreshScreen();
        }

        /// <summary>
        /// Updates all the movements and collisions.
        /// </summary>
        public void Update()
        {
            _player.MoveShip();
            UpdatePlayerLife();

            _collision.CheckCollisionEnemyPlayer(_player, _enemyManager);
            _collision.CheckCollisionWeaponEnemy(_player.Weapon, _enemyManager);

            if (SwinGame.KeyTyped(KeyCode.SpaceKey))
            {
                _shotType = SwinGame.BitmapNamed("laser");
                _player.Shoot(_shotType);
                SwinGame.RefreshScreen();
                if (_player.Weapon.Shots > 0)
                {
                    _player.Weapon.Shots -= 1;
                }
            }

            if (GameData.Instance.Score >= 7)
            {

                if (SwinGame.KeyTyped(KeyCode.SKey))
                {
                    _shotType = SwinGame.BitmapNamed("laserSpec");
                    _player.Shoot(_shotType);
                    GameData.Instance.Score -= 2;
                    SwinGame.RefreshScreen();
                }
            }

            if (SwinGame.KeyTyped(KeyCode.RKey) && _player.Weapon.Shots <= 5)
            {
                _player.Weapon.ReloadLaser();
            }
        }

        public void UpdatePlayerLife()
        {
            if (GameData.Instance.PlayerHealth <= 0)
            {
                GameData.Instance.PlayerHealth = 100;
                GameData.Instance.PlayerLives -= 1;
            }
        }

        /// <summary>
        /// Draws the background, and all other required information.
        /// </summary>
        public void DrawGameDetails()
        {
            SwinGame.DrawBitmap("background", 0, 0);
            SwinGame.FillRectangle(Color.Black, 0, 0, 1280, 50);
            SwinGame.DrawBitmap("spacewars", 0, 0);
            SwinGame.DrawText("Score: ", Color.White, 1140, 15);
            SwinGame.DrawText((GameData.Instance.Score.ToString()), Color.White, 1200, 15);
            SwinGame.DrawText("Health: ", Color.White, 1140, 35);
            SwinGame.DrawText(GameData.Instance.PlayerHealth.ToString(), Color.White, 1200, 35);
            SwinGame.DrawText("Level: ", Color.White, 1040, 35);
            SwinGame.DrawText(GameData.Instance.CurrentLevel.ToString(), Color.White, 1100, 35);
            SwinGame.DrawText("Shots: ", Color.White, 1040, 15);
            SwinGame.DrawText(_player.Weapon.Shots.ToString(), Color.White, 1100, 15);
            SwinGame.DrawText("Lives: ", Color.White, 940, 15);
            SwinGame.DrawText(GameData.Instance.PlayerLives.ToString(), Color.White, 1000, 15);

            if(_player.Weapon.Shots <= 0)
            {
                SwinGame.DrawText("PRESS R KEY TO RELOAD LASER!", Color.Red, 500, 15);
            }

            if (GameData.Instance.Score >= 7)
            {
                SwinGame.DrawText("SPECIAL WEAPON READY TO DEPLOY", Color.Red, 500, 35);
            }

            else
            {
                SwinGame.DrawText("SPECIAL WEAPON CHARGING...", Color.Red, 500, 35);
            }
        }

        /// <summary>
        /// Loads all resources ie: images and sounds for the game.
        /// </summary>
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
            SwinGame.LoadBitmapNamed("explode", "explosion.png");


            SwinGame.LoadMusicNamed("Limits", "Limits.wav");
            SwinGame.LoadSoundEffectNamed("Laser", "laser.wav");
            SwinGame.LoadSoundEffectNamed("Explode", "Explosion.wav");
            SwinGame.LoadSoundEffectNamed("Reload", "reload.wav");
            SwinGame.LoadSoundEffectNamed("Ammo", "Ammo.wav");

            _player.Type = SwinGame.BitmapNamed("ship");
        }

        public bool Active { get => _active; set => _active = value; }
    }
}