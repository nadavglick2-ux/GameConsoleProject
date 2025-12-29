using GameConsole.Data;
using GameConsole.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace GameConsole.Base
{
    internal class GamesDetail : Screen
    {
        User _user;
        public GamesDetail(User user) : base("Games Detail")
        {
            _user = user;
        }
       
        public override void Show()
        {
            base.Show();
            char input = '5';
            do
            {
                input = ChooseOptions();


                switch (input)
                {
                    case '1':
                        IReadOnlyList<User> users = UserDb.GetAllUsers();
                        var sortedUsers = users.OrderBy(u => u.Name).ToList();
                        foreach (var user in sortedUsers)
                        {
                            CenterText($"Name: {user.Name} | Username: {user.Username}");
                            foreach (var score in user.HighScores)
                            {
                                CenterText($"  - {score.GameName}: {score.Score}");
                            }
                        }

                        Console.ReadKey(true);
                        break;
                    case '2':
                        Console.Clear();
                        CenterText("=== Users Sorted by High Scores ===");
                        Console.WriteLine();

                        IReadOnlyList<User> users2 = UserDb.GetAllUsers();
                        var sortedByHighScore = users2
                            .OrderByDescending(u => u.HighScores.Any() ? u.HighScores.Max(s => s.Score) : 0)
                            .ToList();

                        foreach (var user in sortedByHighScore)
                        {
                            int maxScore = user.HighScores.Any() ? user.HighScores.Max(s => s.Score) : 0;
                            CenterText($"Name: {user.Name} | Username: {user.Username} | Best Score: {maxScore}");

                            var scoresSorted = user.HighScores.OrderByDescending(s => s.Score);
                            foreach (var score in scoresSorted)
                            {
                                CenterText($"  - {score.GameName}: {score.Score}");
                            }
                            Console.WriteLine();
                        }

                        CenterText("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case '3':
                        Console.Clear();
                        UpName upName = new UpName(_user);
                        upName.Show();
                        break;
                    case '4':
                        break;
                    default:
                        CenterText("--------------------------------");
                        CenterText("Error - Invalid choice");
                        CenterText("--------------------------------");
                        CenterText("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
                Console.Clear();
            } while (input != '4');
        }

        private char ChooseOptions()
        {
            CenterText("Available games options:");
            CenterText("1. Show games by sorted names");
            CenterText("2. Show games by high scored");
            CenterText("3. Show last game");
            CenterText("4. Exit");
            Console.WriteLine();
            CenterText("Choose (1-4):");

            return Console.ReadKey(true).KeyChar;
        }

    }
}