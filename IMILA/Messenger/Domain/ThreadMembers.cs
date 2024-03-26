using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Domain
{
    public class ThreadMembers
    {
        [Key]
        public long ThreadMemberId { get; set; }

        [ForeignKey("UserAccount")]
        public long ThreadMemberUserAccountId { get; set; }

        [ForeignKey("Threads")]
        public int ThreadId { get; set; }
        public required string MemberRole { get; set; }

        public virtual required UserAccount UserAccount { get; set; }
        public virtual required Threads Thread { get; set; }
    }
}
