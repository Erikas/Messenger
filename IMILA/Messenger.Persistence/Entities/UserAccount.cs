using Messenger.Persistence.Entities.Common;

namespace Messenger.Persistence.Entities
{
    internal class UserAccount : IAuditable
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }
        public required bool IsActive { get; set; }
        public required User User { get; set; }
        public virtual required UserSettings UserSettings { get; set; }
        public virtual required ICollection<UserContact> UserContacts { get; set; }
        public virtual required ICollection<ThreadMember> ThreadMembers { get; set; }
        public virtual required ICollection<Thread> Threads { get; set; }
        public virtual required ICollection<Message> Messages { get; set; }
        public DateTime CreationTS { get; set; }
        public DateTime ModificationTS { get; set; }
    }
}
