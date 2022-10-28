using Microsoft.AspNetCore.SignalR;
using System;

namespace JobsForAll.Library.Models
{
    public class MessageViewModel : Hub
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
    }
}
