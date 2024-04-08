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
        public required virtual User User1 { get; set; }
        public required virtual User User2 { get; set; }
        public required virtual Thread Thread { get; set; }
    }
}