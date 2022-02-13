using System;
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

        public void LoadSuccess()
        {
            WriteLine("Address book successfully loaded!");
        }

        public void NoEntries()
        {
            WriteLine("No entries found!");
        }

        public void Arrows()
        {
            Write(">>> ");
        }

        public void ViewPage(List<AddressEntryModel> entries)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                WriteLine($"{i}. {entries[i].LastName}, {entries[i].FirstName}");
            }
            WriteLine();
            WriteLine("Enter the number of your selection to see entry details.");
            WriteLine("To see sorting options, type 'sort', or type the appropriate sorting command if known.");
            WriteLine("To navigate from page to page, type 'next' or 'previous'.");
            Arrows();
        }

        public void Menu(MenuModel menu)
        {
            WriteLine(menu.Name + "\n");
            foreach(MenuOptionModel option in menu.Options)
            {
                WriteLine($"{option.Number} {option.Name}");
            }
        }
    }
}
