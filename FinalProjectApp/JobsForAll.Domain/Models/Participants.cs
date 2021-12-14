using FinalProjectApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Domain.Models
{
    public class Participants
    {
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        public Chat Chat { get; set; }
 
    }
}
