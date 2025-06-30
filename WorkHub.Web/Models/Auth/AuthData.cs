using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkHub.Web.Models.Auth
{
     public class AuthData
     {
          [Required(ErrorMessage = "Email-ul este obligatoriu")]
          public string Email { get; set; }
          [Required(ErrorMessage = "Parola este obligatorie")]
          public string Password { get; set; }
     }
}