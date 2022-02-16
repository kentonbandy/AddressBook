using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class ValidInputDict
    {
        public Dictionary<string, Action> Inputs { get; set; }

        public ValidInputDict(Dictionary<string, Action> Inputs)
        {
            this.Inputs = Inputs;
        }

        public Action? Validate(string input)
        {
            if (input == null) return null;
            input = input.Trim().ToLower();
            try
            {
                return Inputs[input];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
