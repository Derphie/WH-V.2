using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkHub.Web.Models.Chat
{
     public class ChatModel
     {
          public List<Chat> AllChats { get; set; }
          public Chat ActiveChat { get; set; }
          public List<ChatMessage> Messages { get; set; }
     }
}