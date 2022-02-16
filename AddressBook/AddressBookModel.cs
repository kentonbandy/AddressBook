using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace AddressBook
{
    internal class AddressBookModel
    {
        public long GuidMarker { get; set; }
        public List<AddressEntryModel> Entries { get; set; }

        public AddressBookModel()
        {
            GuidMarker = 0;
            Entries = new List<AddressEntryModel>();
        }

        public AddressBookModel(long GuidMarker, List<AddressEntryModel> Entries)
        {
            this.GuidMarker = GuidMarker;
            this.Entries = Entries;
        }

        public bool Add(AddressEntryModel entry)
        {
            if (entry == null) return false;
            entry.Guid = GuidMarker;
            Entries.Add(entry);
            GuidMarker += 1;
            return false;
        }
    }
}
