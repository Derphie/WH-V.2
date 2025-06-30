using System.Collections.Generic;
using System.Web.Mvc;

namespace WorkHub.Web.Controllers
{
     public class ServicesController : Controller
     {
          private bool IsAdmin()
          {
               return (Session["Level"] as int? == 100);
          }

          public ActionResult Web()
          {
               if (IsAdmin()) return RedirectToAction("Index", "Admin");
               return View("ServiceWeb");
          }

          public ActionResult Design()
          {
               if (IsAdmin()) return RedirectToAction("Index", "Admin");
               return View("ServiceDesign");
          }

          public ActionResult Marketing()
          {
               if (IsAdmin()) return RedirectToAction("Index", "Admin");
               return View("ServiceMarketing");
          }

          public ActionResult Editing()
          {
               if (IsAdmin()) return RedirectToAction("Index", "Admin");
               return View("ServiceEditing");
          }

          public ActionResult Translation()
          {
               if (IsAdmin()) return RedirectToAction("Index", "Admin");
               return View("ServiceTranslation");
          }

          public ActionResult Students()
          {
               if (IsAdmin()) return RedirectToAction("Index", "Admin");
               return View("ServiceStudents");
          }
     }
}