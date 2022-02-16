using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AddressBook
{
    internal class CLIIn
    {

        public string? GetStringInput()
        {
            return ReadLine();
        }

        public int? GetIntInput(int low = 1, int high = 2000000000)
        {
            string? userInput = ReadLine();
            if (userInput == null) return null;
            if (userInput == "quit") Environment.Exit(0);
            try
            {
                int num = Convert.ToInt32(userInput);
                if (num >= low && num <= high) return num;
            }
            catch (FormatException) { }
            return null;
        }
    }
}
