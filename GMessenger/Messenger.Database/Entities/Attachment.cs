namespace Messenger.Database.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public int MessageId { get; set; }
        public DateTime UploadTimeStamp { get; set; }
        public required virtual Message Message { get; set; }
    }
}