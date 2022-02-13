using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class MenuOptionModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public Action Action { get; set; }

        public MenuOptionModel(int number, string name, Action action)
        {
            Number = number;
            Name = name;
            Action = action;
        }
    }
}
