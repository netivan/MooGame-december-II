using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MooGame.Interfaces
{
    public class ConsoleIO : IUserInterface
    {
        public void output(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(s);

        }


        public string input()
        {

            return Console.ReadLine();
        }

    }

}
