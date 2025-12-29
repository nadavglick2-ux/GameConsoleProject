using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    internal class NewName
    {
        public static void SampleMethod()
        {
            Console.WriteLine("Do you want a new name");
            String response = Console.ReadLine() ?? string.Empty;
            
        }
    }
}
