using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; internal set; }
        public string Postcode { get; internal set; }
        public string Profession { get; internal set; }
        public string Details { get; internal set; }
    }
}