using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorkHub.Web.Models.Chat
{
     public class Chat
     {
          [Key]
          public int Id { get; set; }

          [Required]
          public string Title { get; set; }

          [Required]
          public string CreatedBy { get; set; }

          public DateTime CreatedAt { get; set; } = DateTime.Now;

          public string Topic { get; set; }

          [InverseProperty("Chat")]
          public virtual ICollection<ChatMessage> Messages { get; set; }
     }

}