using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Profession { get; set; }
        public string Details { get; set; }

        public Role Role { get; set; }
    }

}