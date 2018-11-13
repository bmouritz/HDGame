using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
     public class MenuManager
    {
        private bool _clicked;
        private string _menuChoice;
        private bool _active;
        MenuKind menuChoice = new MenuKind();

        public MenuManager()
        {
            Clicked = false;
            LoadAssets();
            Active = true;
        }

        /// <summary>
        /// Checks if the game is running.
        /// </summary>
        /// <returns>active or not.</returns>
        public bool Running()
        {
            if (SwinGame.WindowCloseRequested())
            {
                Active = false;
            }
            return Active;
        }

        /// <summary>
        /// This checks where the user has clicked on the screen.
        /// </summary>
        /// <returns>Yes if clicked.</returns>
        public bool ButtonClicked(int paramX, int paramY, int width, int height)
        {
            Single xAxishover, yAxishover, btnWidth, btnHeight;

            xAxishover = SwinGame.MouseX();
            yAxishover = SwinGame.MouseY();
            btnWidth = paramX + width;
            btnHeight = paramY + height;

            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if ((xAxishover >= paramX) && (xAxishover <= btnWidth) && (yAxishover >= paramY) && (yAxishover <= btnHeight))
                {
                    Clicked = true;
                }
            }
            else
            {
                Clicked = false;
            }
            return Clicked;
        }

        /// <summary>
        /// Runs through the main menu system.
        /// </summary>
        public void MainMenu()
        {
            menuChoice.Draw("menu", menuChoice.X, menuChoice.Y);
            if (ButtonClicked(322, 231, 610, 120))
            {
                do
                {
                    HowTo();
                } while (ButtonClicked(840, 180, 180, 50) == false);
                Active = false;
            }
        }

        /// <summary>
        /// Draws the HowTo Menu
        /// </summary>
        public void HowTo()
        {
            menuChoice.X = 217;
            menuChoice.Y = 172;
            menuChoice.Draw("howto", menuChoice.X, menuChoice.Y);
        }


        public void DeathMenu()
        {
            menuChoice.X = 0; 
            menuChoice.Y = 0;
            menuChoice.Draw("replay", menuChoice.X, menuChoice.Y);
        }

        /// <summary>
        /// Loads the assets for the menu systems.
        /// </summary>
        public void LoadAssets()
        {
            SwinGame.LoadBitmapNamed("menu", "menu.png");
            SwinGame.LoadBitmapNamed("howto", "menuhowto.png");
            SwinGame.LoadBitmapNamed("chooseship", "chooseship.png");
            SwinGame.LoadBitmapNamed("ship1", "shippick.png");
            SwinGame.LoadBitmapNamed("replay", "replay.png");
        }

        public bool Clicked { get => _clicked; set => _clicked = value; }
        public string MenuChoice { get => _menuChoice; set => _menuChoice = value; }
        public bool Active { get => _active; set => _active = value; }
    }
}
