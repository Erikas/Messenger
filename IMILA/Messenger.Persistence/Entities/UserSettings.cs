using Messenger.Persistence.Entities.Common;

namespace Messenger.Persistence.Entities
{
    public class UserSettings : IAuditable
    {
        public long Id { get; set; }
        public long UserAccountId { get; set; }
        public required bool Theme { get; set; }
        public virtual required UserAccount UserAccount { get; set; }
        public DateTime CreationTS { get; set; }
        public DateTime ModificationTS { get; set; }
    }
}
