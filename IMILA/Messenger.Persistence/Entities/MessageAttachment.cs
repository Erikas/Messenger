using Messenger.Persistence.Entities.Common;

namespace Messenger.Persistence.Entities
{
    public class MessageAttachment : IAuditable
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public long MessageId { get; set; }
        public required Uri BlobUrl { get; set; }
        public required virtual Message Message { get; set; }
        public DateTime CreationTS { get; set; }
        public DateTime ModificationTS { get; set; }
    }
}
