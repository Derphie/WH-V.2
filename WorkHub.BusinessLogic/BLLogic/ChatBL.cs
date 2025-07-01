using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.BusinessLogic.Core;
using WorkHub.BusinessLogic.Interfaces;
using WorkHub.Domain.Enums;
using WorkHub.Web.Models.Chat;

namespace WorkHub.BusinessLogic.BLLogic
{
     public class ChatBL : ChatApi, IChat
     {
          public void CreateChat(string title, string createdBy, string topic)
          {
               CreateChatAction(title, createdBy, topic);
          }

          public List<Chat> GetAllChats()
          {
               return GetAllChatsAction();
          }

          public Chat GetChatById(int id)
          {
               return GetChatByIdAction(id);
          }

          public void SendMessage(int chatId, string sender, string content, URole role)
          {
               SendMessageAction(chatId, sender, content, role);
          }

          public List<ChatMessage> GetMessagesForChat(int chatId)
          {
               return GetMessagesForChatAction(chatId);
          }

          public void DeleteChat(int chatId)
          {
               DeleteChatAction(chatId);
          }

     }
}
