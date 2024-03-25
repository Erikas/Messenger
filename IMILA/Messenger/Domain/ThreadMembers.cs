using System.ComponentModel.DataAnnotations;

namespace Messenger.Domain
{
    public class ThreadMembers
    {
        [Key]
        public long ThreadMemberId { get; set; }
        public required List<UserAccount> ThreadMemberUserAccountId { get; set; }
        public required List<Threads> ThreadId { get; set; }
        public required string MemberRole { get; set; }
    }
}
