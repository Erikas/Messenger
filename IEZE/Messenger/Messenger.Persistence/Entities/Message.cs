namespace Messenger.Persistence.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int ThreadID { get; set; }
        public int SenderUserID { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        public virtual ChatThread ChatThread { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<MessageAttachment> MessageAttachment { get; set; }
    }
}
