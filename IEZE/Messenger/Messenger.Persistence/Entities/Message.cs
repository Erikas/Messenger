namespace Messenger.Persistence.Entities
{
    public class Message
    {
        public required int MessageID { get; set; }
        public required int ThreadID { get; set; }
        public required int SenderUserID { get; set; }
        public required string Content { get; set; }
        public required DateTime SentAt { get; set; }

        public required ChatThread ChatThread { get; set; }
        public required User SenderUser { get; set; }
        public required ICollection<Attachment> Attachments { get; set; }
    }
}
