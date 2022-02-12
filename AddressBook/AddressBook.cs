using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace AddressBook
{
    internal class AddressBook
    {
        public List<AddressEntryModel> Entries { get; set; }

        public AddressBook()
        {
            Entries = new List<AddressEntryModel>();
        }

        public AddressBook(List<AddressEntryModel> entries, string path)
        {
            Entries = entries;
        }

        public bool Add(AddressEntryModel entry)
        {
            if (entry == null) return false;
            int c = Entries.Count;
            Entries.Add(entry);
            int c2 = Entries.Count;
            return c2 > c;
        }
    }
}
