using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class AddressEntryModel
    {
        public long Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Country { get; set; }
        public string Postal_code { get; set; }
        public bool IsInternational { get; set; }
        public int? Phone { get; set; }
        public string[] Groups { get; set; }
        public DateOnly Date { get; set; }

        public AddressEntryModel(long guid, string firstName, string lastName, string address1, string? address2, string city, string area, string country, string postal_code, bool isInternational, int? phone, string[] groups, DateOnly date)
        {
            Guid = guid;
            FirstName = firstName;
            LastName = lastName;
            Address1 = address1;
            Address2 = address2;
            City = city;
            Area = area;
            Country = country;
            Postal_code = postal_code;
            IsInternational = isInternational;
            Phone = phone;
            Groups = groups;
            Date = date;
        }
    }
}
