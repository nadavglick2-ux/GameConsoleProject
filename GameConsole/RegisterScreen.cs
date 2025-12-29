using GameConsole.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole.Pages
{
    internal class RegisterScreen : Screen
    {
        public RegisterScreen() : base("Register Page")
        {
        }
        public override void Show()
        {
            base.Show();
            CenterText("Enter Your Desired Details");
            NewUser newUser = new NewUser();
            newUser.CreateUser();
        }
    }
}