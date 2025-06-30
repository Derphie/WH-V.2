using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WorkHub.Web.App_Start
{
     public class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {
               // Bundle css
               bundles.Add(new StyleBundle("~/bundles/app/css").Include(
                    "~/Content/app.css", new CssRewriteUrlTransform()));


               // Boostrap js
               bundles.Add(new ScriptBundle("~/bundles/script/js").Include(
                    "~/Scripts/script.js"));
          }
     }
}