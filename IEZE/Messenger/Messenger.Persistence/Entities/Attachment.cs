namespace Messenger.Persistence.Entities
{
    public class Attachment
    {
        public int AttachmentID { get; set; }
        public int MessageID { get; set; }
        public required string AttachmentName { get; set; }
        public required string AttachmentURL { get; set; }
        public int UploadedByUserID { get; set; }
        public DateTime UploadedAt { get; set; }

        public required Message Message { get; set; }
        public required User UploadedByUser { get; set; }
    }
}
