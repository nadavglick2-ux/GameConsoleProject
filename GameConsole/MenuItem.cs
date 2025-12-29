using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole.Base
{
    internal class MenuItem
    {
        public string DisplayName
        {
            get; set;
        }
        public Screen Screen
        {
            get; set;
        }

        public MenuItem(string displayName, Screen screen)
        {
            this.DisplayName = displayName;
            this.Screen = screen;
        }

    }
}