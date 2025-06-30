using System.Collections.Generic;
using WorkHub.BusinessLogic.Core;
using WorkHub.BusinessLogic.Interfaces;
using WorkHub.Domain.Entities.User;

namespace WorkHub.BusinessLogic.BLLogic
{
     public class AdminBL : AdminApi, IAdmin
     {
          public List<UDbTable> GetAllUsers()
          {
               return base.GetAllUsersAction();
          }

          public UDbTable GetUserById(int id)
          {
               return base.GetUserByIdAction(id);
          }

          public bool UpdateUser(UDbTable user)
          {
               return base.UpdateUserAction(user);
          }

          public bool DeleteUser(int id)
          {
               return base.DeleteUserAction(id);
          }
     }
}