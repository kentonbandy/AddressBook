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

        public void ViewPage(List<AddressEntryModel> entries, int current, int total)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                WriteLine($"{i+1}. {clampToWidth(entries[i].LastName + ",", 12)}{entries[i].FirstName}");
            }
            WriteLine();
            WriteLine($"Page {current} of {total}");
            WriteLine();
            WriteLine("Enter the number of your selection to see entry details.");
            WriteLine("To see sorting options, type 'sort', or type the appropriate sorting command if known.");
            WriteLine("To navigate from page to page, type 'next' or 'prev'.");
            WriteLine("Type 'back' or 'main' to return to the main menu.");
            Arrows();
        }

        public void ViewGroups(List<string> groups)
        {
            foreach (string group in groups)
            {
                WriteLine(group);
            }
            WriteLine("Enter the name of a group to view the entries in that group, or type 'back' or 'main' to return to the main menu.");
            Arrows();
        }

        public void Menu(MenuModel menu)
        {
            WriteLine(menu.Name);
            foreach(MenuOptionModel option in menu.Options)
            {
                WriteLine($"{option.Number} {option.Name}");
            }
        }

        public void UserInputError()
        {
            WriteLine("Please provide valid input.");
        }

        public void AtLastPage()
        {
            WriteLine("You're on the last page.");
        }

        public void AtFirstPage()
        {
            WriteLine("You're on the first page.");
        }

        public void NoSuchOption()
        {
            WriteLine("That is not a valid option.");
        }

        public void NoChanges()
        {
            WriteLine("No changes were made.");
        }

        public void IntRequired()
        {
            WriteLine("A valid integer is required for this field (Phone numbers should be written as all integers with no spaces).");
        }

        public void Entry(AddressEntryModel entry)
        {
            if (entry == null)
            {
                WriteLine("Something went wrong; entry does not exist.");
                return;
            }
            WriteLine(clampToWidth("1. First Name:") + entry.FirstName);
            WriteLine(clampToWidth("2. Last Name:") + entry.LastName);
            WriteLine(clampToWidth("3. Address line 1:") + entry.Address1);
            WriteLine(clampToWidth("4. Address line 2:") + entry.Address2);
            WriteLine(clampToWidth("5. City:") + entry.City);
            WriteLine(clampToWidth("6. State (US) or Area:") + entry.Area);
            WriteLine(clampToWidth("7. Country:") + entry.Country);
            WriteLine(clampToWidth("8. Postal Code (zip in US):") + entry.PostalCode);
            WriteLine(clampToWidth("9. Phone number:") + entry.Phone);
            Write(clampToWidth("10. Groups:"));
            for (int i = 0; i < entry.Groups.Count; i++)
            {
                Write(entry.Groups[i]);
                if (i < entry.Groups.Count - 1) Write(", ");
                else WriteLine();
            }
            WriteLine(clampToWidth("Last edit date:") + entry.Date);
            WriteLine();
            WriteLine("To edit fields, enter the number of that field.");
            WriteLine("To delete this entry, type 'delete'.");
            WriteLine("To return to all entries, type 'back'. To return to the main menu, type 'main'.");
            Arrows();
        }

        public void Delete(bool wasSuccessful)
        {
            if (wasSuccessful) WriteLine("Entry successfully deleted.");
            else WriteLine("Something went wrong during entry deletion.");
        }

        public bool Edit(bool wasSuccessful)
        {
            if (wasSuccessful) WriteLine("Entry field successfully updated.");
            else WriteLine("No updates were made.");
            return wasSuccessful;
        }

        public void EditEntryField(string field, string exising)
        {
            WriteLine($"You are editing: {field}: {exising}");
            WriteLine("Enter the new value to edit the entry. If you don't want to edit the data, press enter without typing anything.");
            Arrows();
        }

        public void ConfirmChange(string field, string userInput)
        {
            WriteLine($"Changing {field} to {userInput}. Are you sure? y/n");
            Arrows();
        }

        public void PrintWithArrows(string text)
        {
            WriteLine(text);
            Arrows();
        }

        public void YesNoRequired()
        {
            WriteLine("Please answer with 'y' or 'n'.");
        }

        public void ValidMenuSelection()
        {
            WriteLine("Please enter the number of your choice.");
        }

        public void PressEnter()
        {
            WriteLine("Press Enter to continue.");
            Arrows();
        }

        public void NewEntry(string field = "")
        {
            if (field.Length > 0)
            {
                WriteLine($"Enter {field}");
                WriteLine("Leave blank if no data is needed.");
                Arrows();
            }
            else WriteLine("---NEW ENTRY---");
        }

        public void IsInternational()
        {
            WriteLine("Is this for a U.S. address? y/n");
            Arrows();
        }

        public void ListEntryGroups(List<string> groups)
        {
            if (groups.Any())
            {
                WriteLine("Current groups:");
                for (int i = 0; i < groups.Count; i++)
                {
                    Write(groups[i] + (i == groups.Count - 1 ? "\n" : ", "));
                }
            }
            else WriteLine("This entry doesn't belong to any groups yet.");
        }

        public void AddGroup()
        {
            WriteLine("Enter the name of the group you would like to add this entry to.");
            WriteLine("Be sure to be accurate: spelling and capitalization matter.");
            WriteLine("If you don't want to add the entry to a group, type cancel.");
            Arrows();
        }

        public void EntryAddedSuccess(bool success = true)
        {
            WriteLine("Entry successfully added.");
        }

        public void EntryUpdateSuccess()
        {
            WriteLine("Entry successfully updated.");
        }

        public void SaveError()
        {
            WriteLine("There was a save error; file not updated.");
        }


        private string clampToWidth(string content, int width = 28)
        {
            int len = content.Length;
            if (len >= width) return len > 2 ? content.Substring(0, width - 3) + ".. " : content.Substring(0, len);
            return content.PadRight(width);
        }
    }
}
