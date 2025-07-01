using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WorkHub.BusinessLogic.BLLogic;
using WorkHub.BusinessLogic.BLogic;
using WorkHub.BusinessLogic.Interfaces;

namespace WorkHub.BusinessLogic
{
     public class BussinesLogic
     {
          public ISession GetSessionBL(HttpSessionStateBase session, HttpRequestBase request, HttpResponseBase response)
          {
               return new SessionBL(session, request, response);
          }

          public IUser GetUserBL()
          {
               return new UserBL();
          }

          public IChat GetChatBL()
          {
               return new ChatBL();
          }

          public IAdmin GetAdminBL()
          {
               return new AdminBL();
          }
     }
}
