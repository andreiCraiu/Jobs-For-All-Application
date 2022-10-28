using JobsForAll.Library.Contracts;
using JobsForAll.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;

namespace JobsForAll.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public MessageController(IRepository repository, IHubContext<MessageHub> hubContext)
        {
            this.repository = repository;
            this.hubContext = hubContext;
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
                SendTime = DateTime.Now,
            };

            repository.AddMessages(databaseMessage);
            hubContext.Clients.All.SendAsync("MessageReceived", message);

            return Ok(databaseMessage.ID);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            var messages = repository.GetMessages();
            return Ok(messages);
        }

        //

        private readonly IRepository repository;
        private readonly IHubContext<MessageHub> hubContext;
    }
}
