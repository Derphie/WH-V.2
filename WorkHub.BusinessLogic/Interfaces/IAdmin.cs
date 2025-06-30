using System.Collections.Generic;
using WorkHub.Domain.Entities.User;

namespace WorkHub.BusinessLogic.Interfaces
{
     public interface IAdmin
     {
          List<UDbTable> GetAllUsers();
          UDbTable GetUserById(int id);
          bool UpdateUser(UDbTable user);
          bool DeleteUser(int id);
     }
}