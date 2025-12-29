using GameConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace GameConsole.Data
{
    public static class UserDb
    {
        private static List<User> users;
        private static readonly string DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private static readonly string UsersFile = Path.Combine(DataPath, "users.json");

        static UserDb()
        {
            LoadUsers();
        }
        public static User RegisterUser(string name, string uName, string password)
        {
            if (string.IsNullOrWhiteSpace(uName)) throw new ArgumentException("username required", nameof(uName));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("password required", nameof(password));

            if (users.Any(x => x.Username.Equals(uName, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("user already exists");

            var user = new User(name, uName, password);
            users.Add(user);
            SaveUsers();
            return user;
        }

        public static User? Login(string? uName, string? password)
        {
            if (string.IsNullOrWhiteSpace(uName) || string.IsNullOrWhiteSpace(password)) return null;

            return users.FirstOrDefault(u =>
                u.Username.Equals(uName, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);
        }

        public static void Update(User u)
        {
            if (u is null) throw new ArgumentNullException(nameof(u));

            var existing = users.FirstOrDefault(x => x.Username.Equals(u.Username, StringComparison.OrdinalIgnoreCase));
            if (existing is null) throw new InvalidOperationException("no such user exists");

            existing.Name = u.Name;
            existing.Password = u.Password;
            existing.HighScores = new List<HighScore>(u.HighScores ?? new List<HighScore>());
            SaveUsers();
        }

        // לעזרות בדיקה
        public static IReadOnlyList<User> GetAllUsers() => users.AsReadOnly();

        internal static bool UpdatePassword(string username, string? newPassword)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(newPassword)) return false;

            User user = users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase))!;
            user.Password = newPassword;
            SaveUsers();
            return true;
        }

        internal static bool UpdateName(string username, string? newName)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(newName)) return false;

            User user = users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase))!;
            user.Name = newName;
            SaveUsers();
            return true;
        }
        public static void SaveUsers()
        {
            try
            {
                if (!Directory.Exists(DataPath))
                    Directory.CreateDirectory(DataPath);

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(users, options);
                File.WriteAllText(UsersFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving users: {ex.Message}");
            }
        }

        private static void LoadUsers()
        {
            try
            {
                if (!Directory.Exists(DataPath))
                    Directory.CreateDirectory(DataPath);

                if (File.Exists(UsersFile))
                {
                    string json = File.ReadAllText(UsersFile);
                    users = JsonSerializer.Deserialize<List<User>>(json) ?? new();
                }
                else
                {
                    users = new();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading users: {ex.Message}");
                users = new();
            }
        }
    }
}