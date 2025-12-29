using System;
using System.Linq;
using GameConsole.Data;
using GameConsole.Models;

namespace GameConsole
{
    internal class NewUser
    {
        public void CreateUser()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Register New User ===");


                Console.Write("Name: ");
                string name = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Press any key to try again...");
                    Console.ReadKey(true);
                    continue;
                }


                Console.Write("Username: ");
                string username = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Username cannot be empty. Press any key to try again...");
                    Console.ReadKey(true);
                    continue;
                }

                if (UserDb.GetAllUsers().Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Username already exists. Please choose a different username. Press any key to try again...");
                    Console.ReadKey(true);
                    continue;
                }


                Console.Write("Password: ");
                string password = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Password cannot be empty. Press any key to try again...");
                    Console.ReadKey(true);
                    continue;
                }


                if (UserDb.GetAllUsers().Any(u => u.Password == password))
                {
                    Console.WriteLine("This password is already used by another account. Please enter a different password. Press any key to re-enter password...");
                    Console.ReadKey(true);
                    continue;
                }

                try
                {
                    var newUser = UserDb.RegisterUser(name, username, password);

                    //Application.user = newUser;

                    Console.WriteLine($"Registration successful. Welcome, {newUser.Name}!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);


                    Console.Clear();
//                    var pickGame = new Pages.PickGame();
//                    pickGame.Show();

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Registration failed: {ex.Message}");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
