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
        private int _x, _y;
        private bool _active;
        MenuKind menuChoice = new MenuKind();

        public MenuManager()
        {
            Clicked = false;
            LoadAssets();
            Active = true;
        }

        public bool Running()
        {
            if (SwinGame.WindowCloseRequested())
            {
                Active = false;
            }
            return Active;
        }

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

        public void MainMenu()
        {
            menuChoice.Draw("menu", X, Y);
            if (ButtonClicked(322, 231, 610, 120))
            {
                do
                {
                    HowTo();
                } while (ButtonClicked(840, 180, 180, 50) == false);
                Active = false;
            }
        }

        public void HowTo()
        {
            menuChoice.X = 217;
            menuChoice.Y = 172;
            menuChoice.Draw("howto", menuChoice.X, menuChoice.Y);
        }

        public void ChooseShip()
        {
            menuChoice.Draw("chooseship", menuChoice.X, menuChoice.Y);
        }

        public void Ship1Choice()
        {
            menuChoice.Draw("ship1", menuChoice.X, menuChoice.Y);
        }

        public void Ship2Choice()
        {
            menuChoice.Draw("ship2", menuChoice.X, menuChoice.Y);
        }

        public void LoadAssets()
        {
            SwinGame.LoadBitmapNamed("menu", "menu.png");
            SwinGame.LoadBitmapNamed("howto", "menuhowto.png");
            SwinGame.LoadBitmapNamed("chooseship", "chooseship.png");
            SwinGame.LoadBitmapNamed("ship1", "shippick.png");
            SwinGame.LoadBitmapNamed("ship2", "shippick1.png");
        }

        public bool Clicked { get => _clicked; set => _clicked = value; }
        public string MenuChoice { get => _menuChoice; set => _menuChoice = value; }
        public int Y { get => _y; set => _y = value; }
        public int X { get => _x; set => _x = value; }
        public bool Active { get => _active; set => _active = value; }
    }
}
