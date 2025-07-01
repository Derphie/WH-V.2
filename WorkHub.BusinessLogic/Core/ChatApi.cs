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

     }

}
