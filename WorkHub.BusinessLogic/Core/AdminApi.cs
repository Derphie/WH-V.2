using System;
using System.Collections.Generic;
using System.Linq;
using WorkHub.BusinessLogic.DBModel;
using WorkHub.Domain.Entities.User;
using WorkHub.Domain.Enums;

namespace WorkHub.BusinessLogic.Core
{
     public class AdminApi
     {
          public List<UDbTable> GetAllUsersAction()
          {
               using (var db = new UserContext())
               {
                    return db.Users.ToList();
               }
          }

          public UDbTable GetUserByIdAction(int id)
          {
               using (var db = new UserContext())
               {
                    return db.Users.FirstOrDefault(u => u.Id == id);
               }
          }

          public bool UpdateUserAction(UDbTable user)
          {
               using (var db = new UserContext())
               {
                    var existingUser = db.Users.Find(user.Id);
                    if (existingUser == null) return false;

                    existingUser.Username = user.Username;
                    existingUser.Email = user.Email;
                    existingUser.Level = user.Level;

                    db.SaveChanges();
                    return true;
               }
          }

          public bool DeleteUserAction(int id)
          {
               using (var db = new UserContext())
               {
                    var user = db.Users.Find(id);
                    if (user == null) return false;

                    db.Users.Remove(user);
                    db.SaveChanges();
                    return true;
               }
          }
     }
}