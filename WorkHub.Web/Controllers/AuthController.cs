using System;
using System.Web;
using System.Web.Mvc;
using WorkHub.BusinessLogic;
using WorkHub.BusinessLogic.Interfaces;
using WorkHub.Domain.Entities.User.Auth;
using WorkHub.Web.Models.Auth;
using WorkHub.Domain.Entities.User;

namespace WorkHub.Web.Controllers
{
     public class AuthController : Controller
     {
          private IUser _user;
          private ISession _session;

          protected override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var bl = new BussinesLogic();
               _user = bl.GetUserBL();
               _session = bl.GetSessionBL(
                   new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session),
                   new HttpRequestWrapper(System.Web.HttpContext.Current.Request),
                   new HttpResponseWrapper(System.Web.HttpContext.Current.Response)
               );
               base.OnActionExecuting(filterContext);
          }

          public ActionResult Index()
          {
               return View(new AuthData());
          }

          public ActionResult Logout()
          {
               _session.ClearUserSession();
               return RedirectToAction("Index", "Home");
          }

          [HttpPost]
          public ActionResult Auth(AuthData data)
          {
               if (!ModelState.IsValid)
                    return View("Index", data);

               var auth = new UserAuth
               {
                    Email = data.Email,
                    Password = data.Password,
                    LoginTime = DateTime.Now
               };

               string token = _user.AuthenticateUser(auth);

               if (!string.IsNullOrEmpty(token))
               {
                    var user = _user.GetUserByEmail(auth.Email);
                    _session.SetUserSession(user.Username, (int)user.Level, token, user.Email);
                    return RedirectToAction("Index", "Home");
               }

               ModelState.AddModelError("", "Autentificare eșuată. Verifică datele.");
               return View("Index", data);
          }
     }
}
