using System.Collections.Generic;

namespace MDSoDv2
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FamilyEmail { get; set; }
        public bool Active { get; set; }
        public List<int> ClassIDs { get; set; }
    }
}