using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Messenger.Domain.Common;

namespace Messenger.Domain
{
    public class UserAccount : BaseDomain
    {
        [Key]
        public long UserAccountId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
       
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }
        public required bool IsActive { get; set; }
        public required User User { get; set; }
        public virtual required ICollection<Settings> Settings { get; set; }
        public virtual required ICollection<Contacts> Contacts { get; set; }
        public virtual required ICollection<ThreadMembers> ThreadMembers { get; set; }
        public virtual required ICollection<Threads> Threads { get; set; } 
        public virtual required ICollection<Message> Messages { get; set; } 

    }
}
