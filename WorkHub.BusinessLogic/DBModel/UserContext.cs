using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.Domain.Entities.User;
using WorkHub.Web.Models.Chat;

namespace WorkHub.BusinessLogic.DBModel
{
     class UserContext : DbContext
     {
          public UserContext() : base("name=WorkHub")
          {
               this.Configuration.LazyLoadingEnabled = false;
               this.Configuration.ProxyCreationEnabled = false;
          }

          public virtual DbSet<UDbTable> Users { get; set; }
          public virtual DbSet<Chat> ChatRooms { get; set; }
          public virtual DbSet<ChatMessage> ChatMessages { get; set; }
     }
}
