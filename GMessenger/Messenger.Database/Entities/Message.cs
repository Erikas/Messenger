namespace Messenger.Database.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int MessageSenderId { get; set; }
        public int MessageReceiverId { get; set; }
        public required string MessageText { get; set; }
        public int TredId { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public required virtual ICollection<Attachment> Attachments { get; set; }
        public required virtual User MessangeSender { get; set; }
        public required virtual User MessangeReceiver { get; set; }
        public required virtual Thread Thread { get; set; }
    }
}