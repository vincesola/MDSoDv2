namespace MDSoDv2
{
    public class Class
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassLocation { get; set; }
        public int SessionID { get; set; }
        public string SessionName { get; set; } // Add this property
        public string DayOfWeek { get; set; }
        public string Time { get; set; }
        public string Teachers { get; set; }

        public override string ToString()
        {
            return ClassName;
        }
    }
}