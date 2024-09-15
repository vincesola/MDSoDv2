using System;

namespace MDSoDv2
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int StudentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}