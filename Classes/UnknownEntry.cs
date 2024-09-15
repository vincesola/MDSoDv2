using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSoDv2
{
    public class UnknownEntry
    {
        public string EntityType { get; set; } // Student or Parent
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FieldWithUnknown { get; set; } // The field that contains "Unknown"
    }
}

