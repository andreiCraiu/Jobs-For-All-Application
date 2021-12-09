using FinalProjectApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public string Author { get; set; }
    }
}
