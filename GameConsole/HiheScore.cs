using System;

namespace GameConsole.Models
{
    public class HighScore
    {
        public string GameName { get; set; }
        public int Score { get; set; }

        public DateTime AchievedOn { get; set; }

        public HighScore(string gameName, int score)
        {
            GameName = gameName ?? throw new ArgumentNullException(nameof(gameName));
            Score = score;
            AchievedOn = DateTime.Now;
        }
    }
}