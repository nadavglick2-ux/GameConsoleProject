using GameConsole.Data;
using GameConsole.Models;

namespace GameConsole.Base
{
    internal class UserOperations : Screen
    {
        User _user;
        public UserOperations(User user) : base("User Operations")
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
                        CenterText("User Details:");
                        CenterText($"Name: {_user.Name}");
                        CenterText($"Username: {_user.Username}");
                        CenterText($"Password: {_user.Password}");
                        CenterText("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case '2':
                            Console.Clear();
                            UpPasssward upPasssward = new UpPasssward(_user);
                            upPasssward.Show();
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
            CenterText("Available user operations:");
            CenterText("1. Show user details");
            CenterText("2. Update password");
            CenterText("3. Update name");
            CenterText("4. Exit");
            Console.WriteLine();
            CenterText("Choose (1-4):");

            return Console.ReadKey(true).KeyChar;
        }

    }
}