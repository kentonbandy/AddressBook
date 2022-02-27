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
        public string PostalCode { get; set; }
        public bool IsInternational { get; set; }
        public string? Phone { get; set; }
        public List<string> Groups { get; set; }
        public string Date { get; set; }

        public AddressEntryModel()
        {
            Guid = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;
            City = string.Empty;
            Area = string.Empty;
            Country = string.Empty;
            PostalCode = string.Empty;
            Phone = string.Empty;
            Groups = new List<string>();
            Date = DateTime.Now.ToString("MM-dd-yyyy");
        }

        public AddressEntryModel(long guid, string firstName, string lastName, string address1, string? address2, string city, string area, string country, string postalCode, bool isInternational, string? phone, List<string> groups, DateOnly date)
        {
            Guid = guid;
            FirstName = firstName;
            LastName = lastName;
            Address1 = address1;
            Address2 = address2;
            City = city;
            Area = area;
            Country = country;
            PostalCode = postalCode;
            IsInternational = isInternational;
            Phone = phone;
            Groups = groups;
            Date = DateTime.Now.ToString("MM-dd-yyyy");
        }

        public string? Alias(int i)
        {
            if (i < 1 || i > 10) return null;
            Dictionary<int, string> aliases = new()
            {
                { 1, "first name" },
                { 2, "last name" },
                { 3, "address line 1" },
                { 4, "address line 2" },
                { 5, "city" },
                { 6, "state/area" },
                { 7, "country" },
                { 8, "postal/zip code" },
                { 9, "phone number" },
                { 10, "groups" }
            };
            return aliases[i];
        }

        public bool UpdateFieldByInt(int i, string newData)
        {
            if (i == 1) FirstName = newData;
            else if (i == 2) LastName = newData;
            else if (i == 3) Address1 = newData;
            else if (i == 4) Address2 = newData;
            else if (i == 5) City = newData;
            else if (i == 6) Area = newData;
            else if (i == 7) Country = newData;
            else if (i == 8) PostalCode = newData;
            else if (i == 9) Phone = newData;
            else return false;
            return true;
        }

        public string GetFieldByInt(int i)
        {
            if (i == 1) return FirstName;
            else if (i == 2) return LastName;
            else if (i == 3) return Address1;
            else if (i == 4) return Address2 ?? "";
            else if (i == 5) return City;
            else if (i == 6) return Area;
            else if (i == 7) return Country;
            else if (i == 8) return PostalCode;
            else if (i == 9) return Phone ?? "";
            else return null;
        }
    }
}
