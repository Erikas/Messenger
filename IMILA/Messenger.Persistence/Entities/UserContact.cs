using Messenger.Persistence.Entities.Common;

namespace Messenger.Persistence.Entities
{
    internal class UserContact : IAuditable
    {
        public long Id { get; set; }
        public long UserAccountId { get; set; }
        public long ContactUserAccountId { get; set; }
        public bool IsFriends { get; set; }
        public virtual required UserAccount UserAccount { get; set; }
        public virtual required UserAccount ContactUserAccount { get; set; }
        public DateTime CreationTS { get; set; }
        public DateTime? ModificationTS { get; set; }
    }
}
