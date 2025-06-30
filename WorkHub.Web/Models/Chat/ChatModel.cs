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
          public int UnreadMessagesCount => Messages?.Count(m => m.IsNew) ?? 0;
          public IEnumerable<string> ChatTitles => AllChats?.Select(c => c.Title) ?? Enumerable.Empty<string>();
          public bool HasData => AllChats?.Any() == true || ActiveChat != null || Messages?.Any() == true;
     }
}