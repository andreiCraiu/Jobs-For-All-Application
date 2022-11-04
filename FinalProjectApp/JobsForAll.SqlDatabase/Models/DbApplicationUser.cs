using Microsoft.AspNetCore.Identity;

namespace JobsForAll.SqlDatabase.Models
{
    internal class DbApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Profession { get; set; }
        public string Details { get; set; }
        public int Rating { get; set; }
        public int JobsFinished { get; set; }

        public DbRole Role { get; set; }
    }
}
