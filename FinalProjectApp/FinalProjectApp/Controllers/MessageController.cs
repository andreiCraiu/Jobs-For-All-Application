using FinalProjectApp.Data;
using FinalProjectApp.Models;
using JobsForAll.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsForAll.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageController(ApplicationDbContext context, IHubContext<MessageHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [HttpPost]
        public IActionResult Insert(MessageViewModel message)
        {
            var user = (ApplicationUser)HttpContext.Items["User"];

            var databaseMessage = new Message
            {
                Content = message.Content,
                ReceiverId = message.ReceiverId,
                SenderId = user.Id,
                SendTime = DateTime.Now
            };

            _context.Messages.Add(databaseMessage);
            _context.SaveChanges();


            _hubContext.Clients.All.SendAsync("MessageReceived", message);

            return Ok(databaseMessage.ID);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            var messages = _context.Messages.Select(m => new MessageViewModel
            {
                Content = m.Content,
                Id = m.ID,
                ReceiverId = m.ReceiverId,
                SenderId = m.SenderId,
                SendTime = m.SendTime
            });
            return Ok(messages);
        }
    }
}
