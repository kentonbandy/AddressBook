﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AddressBook
{
    internal class CLIOut
    {
        public void LoadError()
        {
            WriteLine("There was an error loading the address book data!");
        }
    }
}
