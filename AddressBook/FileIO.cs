using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace AddressBook
{
    internal class FileIO
    {
        public string Path { get; set; }
        public string Filename { get; set; }

        public FileIO()
        {
            Path = "../../../../";
            Filename = "AddressBook.json";
        }

        public FileIO(string path, string filename)
        {
            this.Path = path;
            this.Filename = filename;
        }

        public string FullPath()
        {
            return Path + Filename;
        }

        public bool SaveData(AddressBookModel data)
        {
            string jsonString = JsonSerializer.Serialize(data);
            try
            {
                File.WriteAllText(FullPath(), jsonString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public AddressBookModel? LoadData()
        {
            string? jsonString = null;
            if (File.Exists(FullPath()))
            {
                try
                {
                    jsonString = File.ReadAllText(FullPath());
                }
                catch (Exception) { }
            }
            else if (Directory.Exists(Path))
            {
                try
                {
                    AddressBookModel addressBook = new();
                    jsonString = JsonSerializer.Serialize(addressBook);
                    File.WriteAllText(FullPath(), jsonString);
                    return addressBook;
                }
                catch (Exception) { }

            }

            return jsonString == null ? null : JsonSerializer.Deserialize<AddressBookModel>(jsonString);
        }
    }
}
