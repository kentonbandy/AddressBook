using AddressBook;

FileIO fileIO = new FileIO();
AddressBookModel? addressBook = fileIO.LoadData();
CLIOut cliOut = new();

if (addressBook == null)
{
    cliOut.LoadError();
    Environment.Exit(1);
}
else
{
    Console.WriteLine("Success!");
}