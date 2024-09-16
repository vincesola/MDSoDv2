using System;

namespace MDSoDv2
{
    public class Session
    {
        public int SessionID { get; set; }
        public string SessionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}