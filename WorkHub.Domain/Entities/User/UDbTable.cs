using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using WorkHub.Domain.Enums;

namespace WorkHub.Domain.Entities.User
{
     public class UDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          [Display(Name = "Username")]
          [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
          public string Username { get; set; }

          [Required]
          [Display(Name = "Password")]
          [StringLength(100, ErrorMessage = "Password cannot be longer than 100 characters.")]
          public string Password { get; set; }

          [Required]
          [Display(Name = "Email")]
          [StringLength(30)]
          public string Email { get; set; }

          [DataType(DataType.Date)]
          public DateTime LastLogin { get; set; }

          public URole Level { get; set; }
     }
}
