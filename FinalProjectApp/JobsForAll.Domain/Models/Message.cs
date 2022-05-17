using JobsForAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectApp.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }

        public ApplicationUser Sender { get; set; }
        public string SenderId { get; set; }

        public ApplicationUser Receiver { get; set; }
        public string ReceiverId { get; set; }
        public Chat Chat { get; set; }
        public int ChatId { get; set; }
        public string MessageAuthor { get; set; }
    }
}
