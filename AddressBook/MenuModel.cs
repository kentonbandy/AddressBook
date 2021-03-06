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
        public List<MenuOptionModel> Options { get; set; }

        public MenuModel(string name, List<MenuOptionModel> options)
        {
            Name = name;
            Options = options;
        }
    }
}
