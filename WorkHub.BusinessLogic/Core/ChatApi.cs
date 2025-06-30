using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.BusinessLogic.DBModel;
using WorkHub.Domain.Enums;
using WorkHub.Web.Models.Chat;
using System.Data.Entity;

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
                    return db.ChatRooms
                           .Include(c => c.Messages)
                           .OrderByDescending(c => c.CreatedAt)
                           .ToList();
               }
          }

          public Chat GetChatByIdAction(int id)
          {
               using (var db = new UserContext())
               {
                    return db.ChatRooms
                           .Include(c => c.Messages)
                           .FirstOrDefault(c => c.Id == id);
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

          public List<ChatMessage> GetMessagesForChatAction(int chatId, string currentUser)
          {
               using (var db = new UserContext())
               {
                    var messages = db.ChatMessages
                                   .Where(m => m.ChatRoomId == chatId)
                                   .OrderBy(m => m.SentAt)
                                   .ToList();

                    foreach (var msg in messages.Where(m => m.IsNew && m.Sender != currentUser))
                    {
                         msg.IsNew = false;
                    }
                    db.SaveChanges();

                    return messages;
               }
          }

          public int GetUnreadCountForChatAction(int chatId, string username)
          {
               using (var db = new UserContext())
               {
                    return db.ChatMessages
                           .Count(m => m.ChatRoomId == chatId &&
                                  m.IsNew &&
                                  m.Sender != username);
               }
          }

          public void MarkMessageAsReadAction(int messageId)
          {
               using (var db = new UserContext())
               {
                    var message = db.ChatMessages.Find(messageId);
                    if (message != null)
                    {
                         message.IsNew = false;
                         db.SaveChanges();
                    }
               }
          }

          public void DeleteChatAction(int chatId)
          {
               using (var db = new UserContext())
               {
                    var chat = db.ChatRooms.FirstOrDefault(c => c.Id == chatId);
                    if (chat != null)
                    {
                         // Șterge întâi mesajele asociate
                         var messages = db.ChatMessages.Where(m => m.ChatRoomId == chatId);
                         db.ChatMessages.RemoveRange(messages);

                         // Apoi șterge chatul
                         db.ChatRooms.Remove(chat);

                         db.SaveChanges();
                    }
               }
          }

          public void MarkChatAsReadAction(int chatId, string username)
          {
               using (var db = new UserContext())
               {
                    var messages = db.ChatMessages
                                   .Where(m => m.ChatRoomId == chatId &&
                                          m.IsNew &&
                                          m.Sender != username)
                                   .ToList();

                    foreach (var msg in messages)
                    {
                         msg.IsNew = false;
                    }
                    db.SaveChanges();
               }
          }

          public int GetUnreadCountAction(string username)
          {
               using (var db = new UserContext())
               {
                    return db.ChatMessages
                            .Count(m => m.IsNew && m.Sender != username);
               }
          }

     }

}
