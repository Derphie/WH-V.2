using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHub.Domain.Entities.User.Auth
{
     public class UserAuth
     {
          public string Email { get; set; }
          public string Password { get; set; }
          public DateTime LoginTime { get; set; }
     }
}
