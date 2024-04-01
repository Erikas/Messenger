using Messenger.Persistence.Entities.Common;

namespace Messenger.Persistence.Entities
{
    internal class Thread : IAuditable
    {
        public long Id { get; set; }
        public required string ThreadName { get; set; }
        public long CreationUserAccountId { get; set; }
        public required bool IsGroup { get; set; }
        public required Message Message { get; set; }
        public virtual required UserAccount UserAccount { get; set; }
        public virtual required ICollection<Message> Messages { get; set; }
        public virtual required ICollection<ThreadMember> ThreadMembers { get; set; }
        public DateTime CreationTS { get; set; }
        public DateTime? ModificationTS { get; set; }
    }
}
