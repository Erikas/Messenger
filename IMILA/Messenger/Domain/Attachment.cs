using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Domain
{
    public class Attachment
    {

        [Key]
        public long AttachmentId { get; set; }
        [MaxLength(50)]
        public required string AttachmentName { get; set; }

        [ForeignKey("Message")]
        public long MessageId { get; set; }
        public required Uri AttachmentBlobUrl { get; set; }
        public required virtual Message Message { get; set; }

    }
}
