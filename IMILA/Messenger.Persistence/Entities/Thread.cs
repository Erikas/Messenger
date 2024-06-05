using Messenger.Persistence.Entities.Common;

namespace Messenger.Persistence.Entities
{
    public class Thread : IAuditable
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public long CreatorAccountId { get; set; }
        public required bool IsGroup { get; set; }
        public virtual required UserAccount UserAccount { get; set; }
        public virtual required ICollection<Message> Messages { get; set; }
        public virtual required ICollection<ThreadMember> ThreadMembers { get; set; }
        public DateTime CreationTS { get; set; }
        public DateTime ModificationTS { get; set; }
    }
}
