using GameConsole.Base;
using GameConsole.Data;
using GameConsole.Games;
using GameConsole.Models;
using System;

namespace GameConsole.Pages
{
    internal class PickGame : Screen
    {
        private User _currentUser;
        public PickGame(User user) : base("Pick Your Game")
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            _currentUser = user;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine();
            DisplayGames();
        }

        public void DisplayGames()
        {
            char lastChoice = '6';

            do
            {
                CenterText("Available Games:");
                CenterText("1. Tetris");
                CenterText("2. Fluffy Bird");
                CenterText("3. Pac-Man");
                CenterText("4. Show games detail");
                CenterText("5. Exist");
                Console.WriteLine();
                CenterText("Choose (1-5):");

                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.KeyChar == '1')
                {
                    var tetris = new TetrisGame();
                    tetris.Play();
                    UpdateHighScore(tetris.Name, tetris.Score);
                    _currentUser.LastPlayedGame = tetris.Name;
                }
                else if (input.KeyChar == '2')
                {
                    var fluffyBird = new FluffyBirdGame();
                    fluffyBird.Play();
                    UpdateHighScore(fluffyBird.Name, fluffyBird.Score);
                    _currentUser.LastPlayedGame = fluffyBird.Name;
                }
                else if (input.KeyChar == '3')
                {
                    var pacMan = new PacManGame();
                    pacMan.Play();
                    UpdateHighScore(pacMan.Name, pacMan.Score);
                    _currentUser.LastPlayedGame = pacMan.Name;
                }
                else if (input.KeyChar == '4')
                {
                    Console.Clear();
                    var gamesDetail = new GamesDetail(_currentUser);
                    gamesDetail.Show();
                    return;
                }
                else if (input.KeyChar == '5')
                {
                    Console.Clear();
                }
                else
                {
                    CenterText("Invalid choice");
                    Console.ReadKey(true);
                    Console.Clear();
                    Show();
                    return;
                }

                Console.Clear();
            }while (lastChoice != '5');
        }

        private void UpdateHighScore(string gameName, int score)
        {
            HighScore? highScore = _currentUser.HighScores.FirstOrDefault(s => s.GameName == gameName);
            if (highScore != null)
            {
                highScore.Score = Math.Max(highScore.Score, score);
            }
            else
            {
                _currentUser.HighScores.Add(new HighScore(gameName, score));
            }
            UserDb.SaveUsers();
        }
    }
}