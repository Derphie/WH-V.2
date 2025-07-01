using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.BusinessLogic.DBModel;
using WorkHub.Domain.Enums;
using WorkHub.Web.Models.Chat;

namespace WorkHub.BusinessLogic.Core
{
     public class ChatApi
     {
          public void CreateChatAction(string title, string createdBy, string topic)
          {
               using (var db = new UserContext())
               {
                    var chat = new Chat
                    {
                         Title = title,
                         CreatedBy = createdBy,
                         Topic = topic
                    };

                    db.ChatRooms.Add(chat);
                    db.SaveChanges();
               }
          }

          public List<Chat> GetAllChatsAction()
          {
               using (var db = new UserContext())
               {
                    return db.ChatRooms.OrderByDescending(c => c.CreatedAt).ToList();
               }
          }

          public Chat GetChatByIdAction(int id)
          {
               using (var db = new UserContext())
               {
                    return db.ChatRooms.Include("Messages").FirstOrDefault(c => c.Id == id);
               }
          }

          public void SendMessageAction(int chatId, string sender, string content, URole role)
          {
               using (var db = new UserContext())
               {
                    var message = new ChatMessage
                    {
                         ChatRoomId = chatId,
                         Sender = sender,
                         Content = content,
                         SenderRole = role,
                         SentAt = DateTime.Now
                    };

                    db.ChatMessages.Add(message);
                    db.SaveChanges();
               }
          }
     }

}
