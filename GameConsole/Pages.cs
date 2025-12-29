using GameConsole.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole.Pages
{
    internal class WelcomeScreen : Screen
    {
        public WelcomeScreen() : base("Welcome!")
        {
        }
        public override void Show()
        {
            base.Show();

            //Console.SetCursorPosition((Console.WindowLeft + Console.WindowWidth / 2)-Console.CursorLeft, Console.WindowTop + Console.WindowHeight / 2);
            string text = "Welcome to the Game Console Application!";
            CenterText(text);

            CenterText("Press any key to continue");

            Console.ReadKey();
            Screen next = new MainMenu();
            next.Show();
            Console.Clear();
            Console.WriteLine("GoodBye");


        }
    }

}

