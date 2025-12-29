using GameConsole.Base;
using GameConsole.Data;
using GameConsole.Models;

namespace GameConsole
{
    internal class UpName : Screen
    {
        private string _username;
        public UpName(User user) : base("Update Name")
        {
            this._username = user.Username;
        }
        public override void Show()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            base.Show();
            Console.Write("Enter your new name: ");
            string? newName = Console.ReadLine();
            bool isUpdated = UserDb.UpdateName(_username, newName);
            if (isUpdated)
            {
                CenterText("Name updated successfully.");
            }
            else
            {
                CenterText("Failed to update name. Please check your username and new name.");
            }
            CenterText("Press any key to return to user operations menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
