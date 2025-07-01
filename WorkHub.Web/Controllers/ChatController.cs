using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WorkHub.BusinessLogic;
using WorkHub.BusinessLogic.Interfaces;
using WorkHub.Domain.Enums;
using WorkHub.Web.Models.Chat;

namespace WorkHub.Web.Controllers
{
     public class ChatController : Controller
     {
          private IChat _chat;

          protected override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var bl = new BussinesLogic();
               _chat = bl.GetChatBL();
               base.OnActionExecuting(filterContext);
          }

          public ActionResult Chat(int? id)
          {
               if (!id.HasValue)
               {
                    return RedirectToAction("Index");
               }

               var chat = _chat.GetChatById(id.Value);
               var messages = _chat.GetMessagesForChat(id.Value);

               var model = new ChatModel
               {
                    AllChats = _chat.GetAllChats(),
                    ActiveChat = chat,
                    Messages = messages
               };

               return View("Index", model); // Refolosește Index.cshtml
          }

          public ActionResult Index(int? id)
          {
               var username = Session["Username"] as string;
               int? level = Session["Level"] as int?;
               if (string.IsNullOrEmpty(username))
                    return RedirectToAction("Index", "Home");

               bool isMod = level.HasValue && level.Value >= (int)URole.Moderator;

               var allChats = _chat.GetAllChats();
               var visibleChats = isMod
                   ? allChats
                   : allChats.Where(c => c.CreatedBy == username).ToList();

               var model = new ChatModel
               {
                    AllChats = visibleChats,
                    ActiveChat = id.HasValue ? _chat.GetChatById(id.Value) : null,
                    Messages = id.HasValue ? _chat.GetMessagesForChat(id.Value) : new List<ChatMessage>()
               };

               return View("Index", model);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create(string Title, string Topic)
          {
               var username = Session["Username"] as string;
               if (string.IsNullOrEmpty(username)) return RedirectToAction("Index", "Home");
               _chat.CreateChat(Title, username, Topic);
               return RedirectToAction("Index");
          }



          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult SendMessage(int chatRoomId, string content)
          {
               var sender = Session["Username"] as string;
               var level = Session["Level"] as int? ?? 0;
               var role = (URole)level;

               _chat.SendMessage(chatRoomId, sender, content, role);
               return RedirectToAction("Index", new { id = chatRoomId });
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(int id)
          {
               var username = Session["Username"] as string;
               var level = Session["Level"] as int? ?? 0;

               var chat = _chat.GetChatById(id);
               if (chat == null) return HttpNotFound();

               if (chat.CreatedBy == username || level >= (int)URole.Moderator)
               {
                    _chat.DeleteChat(id);
               }

               return RedirectToAction("Index");
          }

     }
}
