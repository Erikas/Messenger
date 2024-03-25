using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Messenger.Domain
{
    public class Message
    {

        [Key]
        public long MessageId { get; set; }
        public required string MessageContent { get; set; }
        public required List<Threads> ThreadId { get; set; }
        public required List<UserAccount> SenderUserAccountId { get; set; }

    }
}
