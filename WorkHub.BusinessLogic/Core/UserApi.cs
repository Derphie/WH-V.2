using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.BusinessLogic.DBModel;
using WorkHub.Domain.Entities.User;
using WorkHub.Domain.Enums;
using WorkHub.Domain.Entities.User.Auth;
using WorkHub.Domain.Entities.User.Reg;
using WorkHub.Helpers;

namespace WorkHub.BusinessLogic.Core
{
     public class UserApi
     {
          protected string AuthenticateUserAction(UserAuth auth)
          {
               using (var db = new UserContext())
               {
                    var hash = PasswordHelper.HashGen(auth.Password);

                    var user = db.Users.FirstOrDefault(u =>
                        u.Email == auth.Email &&
                        u.Password == hash
                    );

                    if (user != null)
                    {
                         user.LastLogin = DateTime.Now;
                         db.SaveChanges();
                         return Guid.NewGuid().ToString(); // sau orice alt sistem de sesiuni
                    }

                    return null;
               }
          }

          protected UDbTable GetUserByEmailAction(string email)
          {
               using (var db = new UserContext())
               {
                    return db.Users.FirstOrDefault(u => u.Email == email);
               }
          }

          protected UserRegDataResp RegisterUserActionCore(RegDataDTO data)
          {
               using (var db = new UserContext())
               {
                    if (db.Users.Any(u => u.Username == data.Username))
                    {
                         return new UserRegDataResp
                         {
                              Status = false,
                              Error = "Acest username este deja folosit."
                         };
                    }

                    if (db.Users.Any(u => u.Email == data.Email))
                    {
                         return new UserRegDataResp
                         {
                              Status = false,
                              Error = "Acest email este deja folosit."
                         };
                    }

                    var hash = PasswordHelper.HashGen(data.Password);

                    var user = new UDbTable
                    {
                         Username = data.Username,
                         Password = hash,
                         Email = data.Email,
                         LastLogin = DateTime.Now,
                         Level = URole.User
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    return new UserRegDataResp
                    {
                         Status = true
                    };
               }
          }
     }
}

