using System.ComponentModel.DataAnnotations;

namespace Messenger.Domain
{
    public class Attachment
    {

        [Key]
        public long AttachmentId { get; set; }
        [MaxLength(50)]
        public required string AttachmentName { get; set; }
        public required List<Message> MessageId { get; set; }
        public required string AttachmentBlobUrl { get; set; }

    }
}
