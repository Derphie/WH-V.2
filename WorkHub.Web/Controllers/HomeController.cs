using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkHub.Web.Controllers
{
     public class HomeController : Controller
     {
          public ActionResult Index()
          {
               var level = Session["Level"] as int?;
               if (level.HasValue && level.Value == 100)
               {
                    return RedirectToAction("Index", "Admin");
               }

               return View();
          }
     }

}