using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectApp.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string job { get; set; }
        public string JobCategory { get; set; }
        public double Price { get; set; }
        public bool IsPriceNegociable { get; set; }
        public string Description { get; set; }
    }
}
