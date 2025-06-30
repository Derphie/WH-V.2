using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WorkHub.BusinessLogic.Core;
using WorkHub.BusinessLogic.DBModel;
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
               return base.GetAllChatsAction();
          }

          public Chat GetChatById(int id)
          {
               return base.GetChatByIdAction(id);
          }

          public void SendMessage(int chatId, string sender, string content, URole role)
          {
               SendMessageAction(chatId, sender, content, role);
          }

          public List<ChatMessage> GetMessagesForChat(int chatId)
          {
               var username = HttpContext.Current?.Session["Username"] as string ?? string.Empty;
               return GetMessagesForChatAction(chatId, username);
          }

          public void DeleteChat(int chatId)
          {
               DeleteChatAction(chatId);
          }

          public int GetUnreadCount(string username)
          {
               return GetUnreadCountAction(username);
          }

          public int GetUnreadCountForChat(int chatId, string username)
          {
               return base.GetUnreadCountForChatAction(chatId, username);
          }

          public void MarkMessageAsRead(int messageId)
          {
               base.MarkMessageAsReadAction(messageId);
          }

          public void MarkChatAsRead(int chatId, string username)
          {
               base.MarkChatAsReadAction(chatId, username);
          }

     }
}
