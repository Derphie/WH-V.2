using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.BusinessLogic.Core;
using WorkHub.BusinessLogic.Interfaces;
using System.Web;

namespace WorkHub.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          private readonly HttpSessionStateBase _session;
          private readonly HttpRequestBase _request;
          private readonly HttpResponseBase _response;

          public SessionBL(HttpSessionStateBase session, HttpRequestBase request, HttpResponseBase response)
          {
               _session = session;
               _request = request;
               _response = response;
          }

          public void SetUserSession(string username, int level, string token, string email)
          {
               _session["Username"] = username;
               _session["Level"] = level;
               _session["Token"] = token;
               _session["Email"] = email;
          }

          public void ClearUserSession()
          {
               _session.Clear();

               if (_request.Cookies["Token"] != null)
               {
                    var cookie = new HttpCookie("Token") { Expires = DateTime.Now.AddDays(-1) };
                    _response.Cookies.Add(cookie);
               }
          }
     }
}

