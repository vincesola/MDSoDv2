namespace MDSoDv2
{
    public class StudentClass
    {
        // Primary key for the StudentClass relationship
        public int StudentClassID { get; set; }

        // Foreign key referencing the Student
        public int StudentID { get; set; }

        // Foreign key referencing the Class
        public int ClassID { get; set; }

        // Additional properties can be added as needed
        // Example: To track payment status for the student in the class
        public bool PaymentStatus { get; set; } // Indicates if the payment is completed

        // Constructor
        public StudentClass()
        {
        }

        public StudentClass(int studentClassID, int studentID, int classID, bool paymentStatus)
        {
            StudentClassID = studentClassID;
            StudentID = studentID;
            ClassID = classID;
            PaymentStatus = paymentStatus;
        }
    }
}