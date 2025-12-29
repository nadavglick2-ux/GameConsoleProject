using GameConsole.Base;
using GameConsole.Data;
using GameConsole.Models;

namespace GameConsole
{
    internal class UpPasssward : Screen
    {
        private string _username;
        public UpPasssward(User user) : base("Update Password")
        {
            this._username = user.Username;
        }
        public override void Show()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            base.Show();
            Console.Write("Enter your new password: ");
            string? newPassword = Console.ReadLine();
            bool isUpdated = UserDb.UpdatePassword(_username, newPassword);
            if (isUpdated)
            {
                CenterText("Password updated successfully.");
            }
            else
            {
                CenterText("Failed to update password. Please check your username and new password.");
            }
            CenterText("Press any key to return to user operations menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
