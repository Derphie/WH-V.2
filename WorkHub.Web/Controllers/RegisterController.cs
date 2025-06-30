using System;
using System.Web;
using System.Web.Mvc;
using WorkHub.BusinessLogic;
using WorkHub.BusinessLogic.Interfaces;
using WorkHub.Domain.Entities.User.Auth;
using WorkHub.Domain.Entities.User.Reg;
using WorkHub.Web.Models.Reg;

namespace WorkHub.Web.Controllers
{
     public class RegisterController : Controller
     {
          private readonly IUser _user;

          public RegisterController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _user = bl.GetUserBL();
          }

          public ActionResult Index()
          {
               return View(new RegData());
          }

          [HttpPost]
          public ActionResult Reg(RegData data)
          {
               if (!ModelState.IsValid)
                    return View("Index", data);

               var reg = new RegDataDTO
               {
                    Username = data.Username,
                    Password = data.Password,
                    Email = data.Email
               };

               var result = _user.RegisterUserAction(reg);

               if (result.Status)
               {
                    var auth = new UserAuth
                    {
                         Email = data.Email,
                         Password = data.Password,
                         LoginTime = DateTime.Now
                    };

                    string token = _user.AuthenticateUser(auth);

                    if (!string.IsNullOrEmpty(token))
                    {
                         var user = _user.GetUserByEmail(data.Email);

                         var session = new BussinesLogic().GetSessionBL(
                             new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session),
                             new HttpRequestWrapper(System.Web.HttpContext.Current.Request),
                             new HttpResponseWrapper(System.Web.HttpContext.Current.Response)
                         );

                         session.SetUserSession(user.Username, (int)user.Level, token, user.Email);
                         return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", "Înregistrarea a reușit, dar autentificarea a eșuat.");
                    return View("Index", data);
               }

               ModelState.AddModelError("", result.Error ?? "Înregistrare eșuată.");
               return View("Index", data);
          }
     }
}
