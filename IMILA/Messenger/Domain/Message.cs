using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Messenger.Domain
{
    public class Message
    {

        [Key]
        public long MessageId { get; set; }
        public required string MessageContent { get; set; }
        [ForeignKey("Threads")]
        public long ThreadId { get; set; }
        [ForeignKey("UserAccount")]
        public long SenderUserAccountId { get; set; }
        public required virtual Threads Thread { get; set; }
        public required virtual UserAccount UserAccount { get; set; }
        public required virtual ICollection<Attachment> Attachments { get; set; }


    }
}
