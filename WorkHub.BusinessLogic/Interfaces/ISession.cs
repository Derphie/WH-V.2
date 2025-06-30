using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHub.BusinessLogic.Interfaces
{
     public interface ISession
     {
          void ClearUserSession();
          void SetUserSession(string username, int level, string token, string email);
     }
}
