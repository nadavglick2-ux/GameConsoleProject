using System;
using GameConsole.Base;
using GameConsole.Pages;
using GameConsole.Data;
using GameConsole.Models;

namespace GameConsole
{
   
    internal class Application
    {
        public static User user { get; private set; }
        public bool IsRunning { get; private set; }

        public Application()
        {
          
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        
        public void Run()
        {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
            IsRunning = true;

            ShowWelcome();

            while (IsRunning)
            {
                ShowMainMenu();
                IsRunning = false;
            }
        }

        public void Exit() => IsRunning = false;

        public void ShowWelcome()
        {
            var welcome = new WelcomeScreen();
            welcome.Show();
        }

        public void ShowMainMenu()
        {
            var menu = new MainMenu();
            menu.Show();
        }

        public void ShowPickGame()
        {
            var pick = new PickGame(user);
            pick.Show();
        }

        public User Register(string name, string username, string password)
        {
            var u = UserDb.RegisterUser(name, username, password);
            user = u;
            return u;
        }

        public void Login(string username, string password)
        {
            user = UserDb.Login(username, password);
        }

        
        public void SaveHighScore(string gameName, int score)
        {
            if (user == null) return;
            user.HighScores.Add(new HighScore(gameName, score));
            UserDb.Update(user);
        }
    }
}