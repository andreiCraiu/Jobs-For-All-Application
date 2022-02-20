using AutoMapper;
using FinalProjectApp.Data;
using FinalProjectApp.Models;
using JobsForAll.Domain.Models;
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
        private readonly IMapper _mapper;

        public MessageController(ApplicationDbContext context, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            _context = context;
            _hubContext = hubContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Insert(MessageViewModel message)
        {
            var sender = (ApplicationUser)HttpContext.Items["User"];
            var receiver = _context.Users.FirstOrDefault(user => user.Id == message.ReceiverId);

            var chat = _context.Chat.FirstOrDefault(chat => chat.ID == message.ChatId);

            if (receiver != null && sender != null)
            {
                var senderParticipant = new Participants();
                var receiverParticipant = new Participants();

                if (chat == null)
                {
                    chat = new Chat();
                    chat.ReceiverChatName = receiver.UserName;
                    chat.SenderChatName = sender.UserName;
                    chat.ChatTitle = receiver.UserName;
                    chat.SenderChatId = sender.Id;
                    chat.ReceiverChatId = receiver.Id;
                    _context.Chat.Add(chat);
                    _context.SaveChanges();

                    senderParticipant.Chat = chat;
                    receiverParticipant.Chat = chat;

                    senderParticipant.User = sender;
                    receiverParticipant.User = receiver;

                    _context.Participants.Add(senderParticipant);
                    _context.Participants.Add(receiverParticipant);
                    _context.SaveChanges();
                }

                var databaseMessage = new Message
                {
                    Content = message.Content,
                    ReceiverId = message.ReceiverId,
                    SenderId = sender.Id,
                    SendTime = DateTime.Now,
                    ChatId = chat.ID
                };
                _context.Messages.Add(databaseMessage);
                _context.SaveChanges();

                _hubContext.Clients.All.SendAsync("MessageReceived", message);

                return Ok(databaseMessage.ChatId);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("loadMessages/{chatID}")]
        public IActionResult GetMessages(int chatID)
        {
            var messages = _context.Messages.Where(m => m.ChatId == chatID).ToList();
            if(messages != null)
            {
                return Ok(messages);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("loadChats/{senderID}")]
        public IActionResult GetChats(string senderID)
        {
            var currentUser = (ApplicationUser)HttpContext.Items["User"];
            var participants = _context.Participants.Where(x => x.User.Id == senderID).ToList();
            var chatViwModelList = new List<ChatViewModel>();

            if(participants != null)
            {
                foreach(var participant in participants)
                {
                    var chat = _context.Chat.FirstOrDefault(chat => chat.ID == participant.ChatId);
                    if(currentUser.Id == chat.SenderChatId)
                    {
                        chat.ChatTitle = chat.ReceiverChatName;
                    }
                    else
                    {
                        chat.ChatTitle = chat.SenderChatName;
                    }
                    var chatViewModel = _mapper.Map<Chat, ChatViewModel>(chat);
                    chatViwModelList.Add(chatViewModel);
                }
               
            }
    
            ""return chatViwModelList != null? Ok(chatViwModelList) : BadRequest();
     
        }
    }
}
