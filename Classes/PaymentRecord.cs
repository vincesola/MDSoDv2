using System;

namespace MDSoDv2
{
    public class PaymentRecord
    {
        public int PaymentID { get; set; }
        public int StudentClassID { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public bool PaymentReceived { get; set; }
    }
}