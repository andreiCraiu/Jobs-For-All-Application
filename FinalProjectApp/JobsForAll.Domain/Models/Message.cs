﻿using System;

namespace JobsForAll.Domain.Models
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
    }
}
