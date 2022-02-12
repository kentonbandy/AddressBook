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
        public string path { get; set; }
        public string filename { get; set; }

        public FileIO()
        {
            path = ".";
            filename = "AddressBook.json";
        }

        public string FullPath()
        {
            return path + "/" + filename;
        }

        public bool SaveData(AddressBook data)
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

        public AddressBook? LoadData()
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
            else
            {
                jsonString = JsonSerializer.Serialize(new AddressBook());
                try
                {
                    File.WriteAllText(FullPath(), jsonString);
                }
                catch (Exception) { }
            }

            return jsonString == null ? null : JsonSerializer.Deserialize<AddressBook>(jsonString);
        }
    }
}
