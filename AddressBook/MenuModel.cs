using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class MenuModel
    {
        public string Name { get; set; }
        public Dictionary<int, Action> Options { get; set; }

        public MenuModel(string name, Dictionary<int, Action> options)
        {
            Name = name;
            Options = options;
        }
    }
}
