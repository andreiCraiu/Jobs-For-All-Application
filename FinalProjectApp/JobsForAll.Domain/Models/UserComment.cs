using FinalProjectApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Domain.Models
{
    public class UserComment
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Comment Comment { get; set; }
    }
}
