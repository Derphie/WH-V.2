using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.BusinessLogic.Core;
using WorkHub.BusinessLogic.Interfaces;
using WorkHub.Domain.Entities.User;
using WorkHub.Domain.Entities.User.Auth;
using WorkHub.Domain.Entities.User.Reg;

namespace WorkHub.BusinessLogic.BLogic
{
     public class UserBL : UserApi, IUser
     {
          public string AuthenticateUser(UserAuth auth)
          {
               return AuthenticateUserAction(auth);
          }

          public UDbTable GetUserByEmail(string email)
          {
               return GetUserByEmailAction(email);
          }

          public UserRegDataResp RegisterUserAction(RegDataDTO data)
          {
               return RegisterUserActionCore(data);
          }
     }
}

