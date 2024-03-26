using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Domain
{
    public class Threads
    {

        [Key]
        public long ThreadId { get; set; }
        public required string ThreadName { get; set; }
        [ForeignKey("UserAccount")]
        public long CreationUserAccountId { get; set; }
        
        public required bool IsGroup { get; set; }
        public required Message Message { get; set; }
        public virtual required UserAccount UserAccount { get; set; }
        public virtual required ICollection<Message> Messages { get; set; }
        public virtual required ICollection<ThreadMembers> ThreadMembers { get; set; }
    }
}
