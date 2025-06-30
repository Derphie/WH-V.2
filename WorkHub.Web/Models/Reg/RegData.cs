using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkHub.Web.Models.Reg
{
     public class RegData
     {
          [Required]
          [StringLength(50, MinimumLength = 5, ErrorMessage = "Numele necesita sa fie intre 5 - 50 caractere")]
          public string Username { get; set; }

          [Required]
          [StringLength(100, MinimumLength = 8, ErrorMessage = "Parola necesita sa fie intre 8 - 100 caractere")]
          [DataType(DataType.Password)]
          public string Password { get; set; }

          [Required]
          [DataType(DataType.Password)]
          [Compare("Password", ErrorMessage = "Parolele nu coincid")]
          public string ConfirmPassword { get; set; }

          [Required]
          [EmailAddress(ErrorMessage = "Email-ul nu este valid")]
          public string Email { get; set; }
     }
}
