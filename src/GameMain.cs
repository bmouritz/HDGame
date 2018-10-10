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

            //while (menu.Running() == true)
            //{
            //    SwinGame.ProcessEvents();
            //    SwinGame.RefreshScreen();
            //    menu.MainMenu();
            //}

            playing.InitiateEnemies();

            while (playing.GameRunning() == true)
            {
                playing.Update();
                playing.Render();
            }
        }
    }
}