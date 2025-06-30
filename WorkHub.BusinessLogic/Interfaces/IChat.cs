using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.Domain.Enums;
using WorkHub.Web.Models.Chat;

namespace WorkHub.BusinessLogic.Interfaces
{
     public interface IChat
     {
          void CreateChat(string title, string createdBy, string topic);
          List<Chat> GetAllChats();
          Chat GetChatById(int id);
          void SendMessage(int chatId, string sender, string content, URole role);
          List<ChatMessage> GetMessagesForChat(int chatId);
          void DeleteChat(int chatId);
          int GetUnreadCount(string username);
          int GetUnreadCountForChat(int chatId, string username);
          void MarkMessageAsRead(int messageId);
          void MarkChatAsRead(int chatId, string username);
     }
}
