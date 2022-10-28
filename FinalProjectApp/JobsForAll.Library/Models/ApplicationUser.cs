namespace JobsForAll.Library.Models
{
    public class ApplicationUser
    {
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Profession { get; set; }
        public string Details { get; set; }
        public int Rating { get; set; }
        public int JobsFinished { get; set; }
        public Role Role { get; set; }
    }

}