namespace Messenger.Persistence.Entities
{
    public class MessageAttachment
    {
        public int Id { get; set; }
        public int MessageID { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentURL { get; set; }
        public int UploadedByUserID { get; set; }
        public DateTime UploadedAt { get; set; }

        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
    }
}
