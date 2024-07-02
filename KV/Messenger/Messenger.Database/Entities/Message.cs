using System;
using System.Collections.Generic;

namespace Messenger.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public int ChatId { get; set; }
        public required Chat Chat { get; set; }
        public int SenderParticipantId { get; set; }
        public required Participant SenderParticipant { get; set; }
        public ICollection<Attachment>? Attachments { get; set; }
        public DateTime ChangeTS { get; set; }
    }
}