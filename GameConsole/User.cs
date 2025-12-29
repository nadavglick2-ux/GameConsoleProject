using System;
using System.Collections.Generic;

namespace GameConsole.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<HighScore>? HighScores { get; set; }

        public string? LastPlayedGame { get; set; }

        public User(string name, string username, string password)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            HighScores = new List<HighScore>();
        }
    }
}