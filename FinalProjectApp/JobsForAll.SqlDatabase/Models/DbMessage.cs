using System;

namespace JobsForAll.SqlDatabase.Models
{
    internal class DbMessage
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        public DbApplicationUser Sender { get; set; }
        public DbApplicationUser Receiver { get; set; }
    }
}
