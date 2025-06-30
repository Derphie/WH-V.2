using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.Domain.Entities.User;
using WorkHub.Domain.Entities.User.Auth;
using WorkHub.Domain.Entities.User.Reg;

namespace WorkHub.BusinessLogic.Interfaces
{
     public interface IUser
     {
          string AuthenticateUser(UserAuth auth);
          UDbTable GetUserByEmail(string email);
          UserRegDataResp RegisterUserAction(RegDataDTO data);
     }
}
