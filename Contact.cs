using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPSample
{
    [Serializable]
    public class Contact
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Number})"; // This will be displayed in the ListBox
        }
    }
}
