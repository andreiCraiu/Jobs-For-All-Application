using Microsoft.AspNetCore.Identity;

namespace JobsForAll.Library.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Profession { get; set; }
        public string Details { get; set; }
        public int Rating { get; set; }
        public int JobsFinished { get; set; }
        public Role Role { get; set; }
    }

}