using GameConsole.Base;
using GameConsole.Data;
using GameConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole.Pages
{
    internal class LoginScreen : Screen
    {
        public LoginScreen() : base("Login Page")
        {
        }
        public override void Show()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            base.Show();
            Console.Write("Enter username: ");
            string? username = Console.ReadLine();
            Console.Write("Enter password: ");
            string? password = Console.ReadLine();
            User? user = UserDb.Login(username, password);
            if (user is null)
            {
                HandleLoginFailure();
                return;
            }
            CenterText("Login succeeded");
            CenterText("Choose game menu or user operations");
            CenterText("1. Game menu");
            CenterText("2. User operations");
            Console.WriteLine();
            CenterText("Choose (1-2):");

            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.KeyChar == '1')
            {
                Console.Clear();
                Screen pickGame = new PickGame(user);
                pickGame.Show();
            }
            else if (input.KeyChar == '2')
            {
                Console.Clear();
                UserOperations userOperations = new UserOperations(user);
                userOperations.Show();
            }

        }

        private void HandleLoginFailure()
        {
            CenterText("Login failed. Invalid username or password.");
            Console.WriteLine();
            CenterText("Press any key to return to main menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}