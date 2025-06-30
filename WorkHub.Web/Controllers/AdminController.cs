using System.Web.Mvc;
using WorkHub.BusinessLogic.Interfaces;
using WorkHub.Domain.Entities.User;

namespace WorkHub.Web.Controllers
{
     public class AdminController : Controller
     {
          private readonly IAdmin _admin;

          public AdminController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _admin = bl.GetAdminBL();
          }

          protected override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               Session["LayoutOverride"] = "~/Views/Shared/_Layout_Admin.cshtml";
               base.OnActionExecuting(filterContext);
          }

          public ActionResult Index()
          {
               if (!IsAdmin()) return RedirectToAction("Index", "Home");
               return View();
          }

          public ActionResult Users()
          {
               if (!IsAdmin()) return RedirectToAction("Index", "Home");

               var users = _admin.GetAllUsers();
               return View(users);
          }

          [HttpGet]
          public ActionResult Edit(int id)
          {
               if (!IsAdmin()) return RedirectToAction("Index", "Home");

               var user = _admin.GetUserById(id);
               if (user == null) return HttpNotFound();

               return View(user);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(UDbTable user)
          {
               if (!IsAdmin()) return RedirectToAction("Index", "Home");

               if (ModelState.IsValid)
               {
                    if (_admin.UpdateUser(user))
                    {
                         return RedirectToAction("Users");
                    }
                    ModelState.AddModelError("", "Error updating user");
               }
               return View(user);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(int id)
          {
               if (!IsAdmin()) return RedirectToAction("Index", "Home");

               if (_admin.DeleteUser(id))
               {
                    return RedirectToAction("Users");
               }
               return HttpNotFound();
          }

          private bool IsAdmin()
          {
               return Session["Level"] != null && (int)Session["Level"] == 100;
          }
     }
}