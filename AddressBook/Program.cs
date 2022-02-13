using AddressBook;

FileIO fileIO = new FileIO();
AddressBookModel? addressBook = fileIO.LoadData();
CLIOut cliOut = new();

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

// Build menus

MenuOptionModel viewAll = new MenuOptionModel(1, "View all entries", viewAllEntries);

List<MenuOptionModel> mainOptions = new List<MenuOptionModel>() {viewAll};

MenuModel mainMenu = new MenuModel("Main Menu", mainOptions);


void viewAllEntries()
{
    int count = addressBook.Entries.Count;
    if (count == 0) cliOut.NoEntries();
    int page = 1;
    int pages = count < 21 ? 1 : (int)Math.Ceiling(count / 20.0);
    while (true)
    {
        cliOut.ViewPage(addressBook.Entries.GetRange(20, (count * 20) - 20));
    }
}

cliOut.Menu(mainMenu);