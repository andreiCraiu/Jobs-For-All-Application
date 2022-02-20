using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Domain.Models
{
    public class Chat
    {
        public int ID { get; set; }
        public string SenderChatName { get; set; }
        public string SenderChatId { get; set; }
        public string ReceiverChatName { get; set; }
        public string ReceiverChatId { get; set; }
        public string ChatTitle { get; set; }
    }
}
