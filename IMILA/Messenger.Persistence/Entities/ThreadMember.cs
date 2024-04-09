using Messenger.Persistence.Entities.Common;

namespace Messenger.Persistence.Entities
{
    internal class ThreadMember : IAuditable
    {
        public long Id { get; set; }
        public long ThreadMemberUserAccountId { get; set; }
        public int ThreadId { get; set; }
        public required string MemberRole { get; set; }
        public virtual required UserAccount UserAccount { get; set; }
        public virtual required Thread Thread { get; set; }
        public DateTime CreationTS { get; set; }
        public DateTime ModificationTS { get; set; }
    }
}
