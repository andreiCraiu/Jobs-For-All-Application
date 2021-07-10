using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectApp.Models
{
    public class JobRequester
    {
        public int ID { get; set; }
        public Job Job { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
