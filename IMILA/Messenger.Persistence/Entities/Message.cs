using Messenger.Persistence.Entities.Common;

namespace Messenger.Persistence.Entities
{
    public class Message : IAuditable
    {
        public long Id { get; set; }
        public required string MessageContent { get; set; }
        public long MessageThreadId { get; set; }
        public long SenderUserAccountId { get; set; }
        public required virtual Thread Thread { get; set; } 
        public required virtual UserAccount UserAccount { get; set; } 
        public required virtual ICollection<MessageAttachment> MessageAttachments { get; set; }
        public DateTime CreationTS { get; set; }
        public DateTime ModificationTS { get; set; }
    }
}
