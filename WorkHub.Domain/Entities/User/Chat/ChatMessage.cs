using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WorkHub.Domain.Enums;

namespace WorkHub.Web.Models.Chat
{
     public class ChatMessage
     {
          [Key]
          public int Id { get; set; }

          [Required]
          public int ChatRoomId { get; set; }

          [Required]
          public string Sender { get; set; } // Utilizator sau Moderator/Admin

          [Required]
          public string Content { get; set; }

          public DateTime SentAt { get; set; } = DateTime.Now;

          [ForeignKey("ChatRoomId")]
          public Chat Chat { get; set; }

          public URole SenderRole { get; set; }
     }

}