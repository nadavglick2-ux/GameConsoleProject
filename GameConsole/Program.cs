using GameConsole.Base;
using GameConsole.Interfaces;
using GameConsole.Pages;

namespace GameConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //        List<IGamePlay> games = new List<IGamePlay>();
            //        games.Add(new Games.TetrisGame());
            //        games.Add(new Games.FluffyBirdGame());
            //        games.Add(new Games.PacManGame());
            //        foreach (var game in games)
            //        {
            //            game.Play();
            //Console.Write($" Game:{game.Name}");
            //Console.WriteLine($"Score:{game.Score}");
            //        }
            //  Screen mainScreen = new Screen("Home Page");
            // mainScreen.Show();
            Screen welcome = new WelcomeScreen();
            welcome.Show();



        }
    }
}