using AddressBook;
using System.Text.Json;

FileIO fileIO = new FileIO();
AddressBookModel? addressBook = fileIO.LoadData();
CLIOut cliOut = new();
CLIIn cliIn = new();

// Verify that the Address book was successfully loaded or created
if (addressBook == null)
{
    cliOut.LoadError();
    Environment.Exit(1);
}
else
{
    cliOut.LoadSuccess();
}

// This key associates a field with an int
Dictionary<int, string> entryFieldKey = new Dictionary<int, string>()
{
    {1, "FirstName"},
    {2, "LastName"},
    {3, "Address1"},
    {4, "Address2"},
    {5, "City"},
    {6, "Area"},
    {7, "Country"},
    {8, "PostalCode"},
    {9, "Phone"},
    {10, "Groups"}
};

// Build menus
MenuOptionModel viewAll = new MenuOptionModel(1, "View all entries", viewAllEntries);
MenuOptionModel viewGroups = new MenuOptionModel(2, "View groups", ViewGroups);
MenuOptionModel searchForEntry = new MenuOptionModel(3, "Search for entry", SearchForEntry);
MenuOptionModel searchForGroup = new MenuOptionModel(4, "Search for group", SearchForGroup);
MenuOptionModel createEntry = new MenuOptionModel(5, "Create New Entry", CreateNewEntry);
MenuOptionModel createGroup = new MenuOptionModel(6, "Create New Group", CreateNewGroup);
MenuOptionModel fileOptions = new MenuOptionModel(7, "File I/O Options", FileIoOptions);
MenuOptionModel manual = new MenuOptionModel(8, "Create New Group", UserManual);


List<MenuOptionModel> mainOptions = new List<MenuOptionModel>()
{
    viewAll, viewGroups, searchForEntry, searchForGroup, createEntry, createGroup, fileOptions, manual
};

MenuModel mainMenu = new MenuModel("Main Menu", mainOptions);



void viewAllEntries()
{
    int count = addressBook.Entries.Count;
    if (count == 0)
    {
        cliOut.NoEntries();
        cliOut.PressEnter();
        cliIn.GetStringInput();
        return;
    }
    int page = 1;
    int pages = count < 21 ? 1 : (int)Math.Ceiling(count / 20.0);
    while (true)
    {
        cliOut.ViewPage(addressBook.Entries.Count > 20 ? addressBook.Entries.GetRange(20, (count * 20) - 20) : addressBook.Entries, page, pages);
        string? userInput = cliIn.GetStringInput();
        if (userInput == null)
        {
            cliOut.UserInputError();
            continue;
        }
        userInput = userInput.Trim().ToLower();
        if (userInput == "next") NextPage(page, pages);
        else if (userInput == "prev") PrevPage(page, pages);
        else if (userInput == "main" || userInput == "back") return;
        else if (userInput == "quit" || userInput == "q") Environment.Exit(0);
        int userInt;
        try
        {
            userInt = Convert.ToInt32(userInput);
        }
        catch (Exception)
        {
            cliOut.NoSuchOption();
            continue;
        }
        if (userInt >= (page * 20) - 19 && userInt <= (page * 20) && userInt <= count)
        {
            if (EntryDetails(addressBook.Entries[userInt - 1])) return;
        }
    }
}

void ViewGroups()
{
    Dictionary<string, List<AddressEntryModel>> groups = new();
    foreach (AddressEntryModel entry in addressBook.Entries)
    {
        foreach (string group in entry.Groups)
        {
            if (groups.ContainsKey(group))
            {
                groups[group].Add(entry);
            }
            else
            {
                groups[group] = new List<AddressEntryModel>() { entry };
            }
        }
    }
    List<string> groupStrings = new List<string>(groups.Keys);
    groupStrings.Sort();
    cliOut.ViewGroups(groupStrings);
}

void SearchForEntry()
{

}

void SearchForGroup()
{

}

void CreateNewEntry()
{
    AddressEntryModel entry = new();
    List<string> groups = new();
    cliOut.NewEntry();
    var entryDict = GetBlankFields();
    string userInput = "";
    while (userInput != "y" && userInput != "yes" && userInput != "n" && userInput != "no")
    {
        cliOut.IsInternational();
        userInput = cliIn.GetStringInput() ?? "";
        userInput = userInput.ToLower();
        if (userInput == "quit" || userInput == "q") Environment.Exit(0);
    }
    entry.IsInternational = userInput == "n" || userInput == "no";
    for (int i = 1; i < 10; i++)
    {
        if (!entry.IsInternational && entryFieldKey[i] == "Country")
        {
            entryDict[entryFieldKey[i]] = "USA";
            continue;
        }
        cliOut.NewEntry(entry.Alias(i));
        userInput = cliIn.GetStringInput() ?? "";
        if (userInput.ToLower() == "quit") Environment.Exit(0);
        entryDict[entryFieldKey[i]] = userInput;
    }
    while (true)
    {
        cliOut.ListEntryGroups(groups);
        if (!GetYesNo("Would you like to add a group?")) break;
        cliOut.AddGroup();
        string userinput = cliIn.GetStringInput() ?? "";
        if (userinput.ToLower() != "cancel") groups.Add(userinput);
    }

    entry.FirstName = entryDict["FirstName"];
    entry.LastName = entryDict["LastName"];
    entry.Address1 = entryDict["Address1"];
    entry.Address2 = entryDict["Address2"];
    entry.City = entryDict["City"];
    entry.Area = entryDict["Area"];
    entry.Country = entryDict["Country"];
    entry.PostalCode = entryDict["PostalCode"];
    entry.Phone = entryDict["Phone"];
    entry.Groups = groups;

    addressBook.Add(entry);
    cliOut.EntryAddedSuccess(SaveLoad());
}

void CreateNewGroup()
{

}

void FileIoOptions()
{

}

void UserManual()
{

}

void NextPage(int page, int pages)
{
    if (page < pages) page++;
    else cliOut.AtLastPage();
}

void PrevPage(int page, int pages)
{
    if (page > 1) page--;
    else cliOut.AtFirstPage();
}

// returning true breaks to main menu, false stays in viewAllEntries
bool EntryDetails(AddressEntryModel entry)
{
    while (true)
    {
        cliOut.Entry(entry);
        string? userInput = cliIn.GetStringInput();
        if (userInput == null)
        {
            cliOut.NoSuchOption();
            continue;
        }
        userInput = userInput.Trim().ToLower();
        if (userInput == "delete")
        {
            cliOut.Delete(DeleteEntry(entry));
            return false;
        }
        if (userInput == "back") return false;
        if (userInput == "main") return true;
        int userInt;
        try
        {
            userInt = Convert.ToInt32(userInput);
        }
        catch (Exception)
        {
            cliOut.NoSuchOption();
            continue;
        }
        if (entry.GetFieldByInt == null)
        {
            cliOut.NoSuchOption();
            continue;
        }
        if (EditField(entry, userInt)) return true;
        else return false;
    }

}

// true: main menu, false; view entries
bool EditField(AddressEntryModel entry, int userInt)
{    
    // display the field info to the user, prompt user to enter new value
    string? userInput;
    string? field = entry.Alias(userInt);
    string property = entryFieldKey[userInt];
    while (true)
    {
        cliOut.EditEntryField(field, entry.GetFieldByInt(userInt));
        userInput = cliIn.GetStringInput();
        if (userInput == "quit") Environment.Exit(0);
        else if (userInput == "main") return true;
        if (userInput == "" || userInput == null)
        {
            cliOut.NoChanges();
            return false;
        }
        if (GetYesNo($"Changing {field} to {userInput}. Are you sure? y/n"))
        {
            if (entry.UpdateFieldByInt(userInt, userInput))
            {
                if (fileIO.SaveData(addressBook)) cliOut.EntryUpdateSuccess();
                else cliOut.SaveError();
                return false;
            }

        }
        else
        {
            cliOut.NoChanges();
            return false;
        }
    }
}

bool DeleteEntry(AddressEntryModel entry)
{
    addressBook.Entries.Remove(entry);
    return SaveLoad();
}

bool SaveLoad()
{
    bool success = fileIO.SaveData(addressBook);
    addressBook = fileIO.LoadData();
    return success;
}

bool GetYesNo(string prompt)
{
    while (true)
    {
        cliOut.PrintWithArrows(prompt);
        string userInput = cliIn.GetStringInput() ?? "";
        userInput = userInput.ToLower();
        if (userInput == "quit") Environment.Exit(0);
        if (userInput == "y" || userInput == "yes") return true;
        if (userInput == "n" || userInput == "no") return false;
        cliOut.YesNoRequired();
    }
}

int MenuSelection(MenuModel menu)
{
    while (true)
    {
        cliOut.Menu(menu);
        int? userInput = cliIn.GetIntInput(1, menu.Options.Count());
        if (userInput != null)
        {
            foreach (MenuOptionModel option in menu.Options)
            {
                if (option.Number == userInput) return userInput.Value;
            }
        }
        cliOut.ValidMenuSelection();
    }
}

Dictionary<string, string> GetBlankFields()
{
    return new()
    {
        { "FirstName", "" },
        { "LastName", "" },
        { "Address1", "" },
        { "Address2", "" },
        { "City", "" },
        { "Area", "" },
        { "Country", "" },
        { "PostalCode", "" },
        { "Phone", "" }
    };
}



// Main program

while (true)
{
    int selection = MenuSelection(mainMenu);
    foreach (MenuOptionModel option in mainMenu.Options)
    {
        if (option.Number == selection)
        {
            option.Action();
            break;
        }
    }
}