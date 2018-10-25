using System;
using SwinGameSDK;

namespace MyGame.src
{
    public class GameMain
    {
        public static void Main()
        {
            GameManager playing = new GameManager();
            MenuManager menu = new MenuManager();
            SwinGame.PlayMusic("Limits");

            while (menu.Running() == true)
            {
                SwinGame.ProcessEvents();
                SwinGame.RefreshScreen();
                menu.MainMenu();
            }

            playing.InitiateEnemies();

            while (playing.GameRunning() == true)
            {
                while (GameData.Instance.PlayerLives != 0)
                {
                    playing.Update();
                    playing.Render();
                    if (GameData.Instance.PlayerLives == 0)
                    {
                        while (menu.ButtonClicked(542, 395, 180, 50) == false)
                        {
                            menu.DeathMenu();
                            menu.FinalScore();
                            playing.ResetGame();
                        }
                    }
                }

            }
        }
    }
}