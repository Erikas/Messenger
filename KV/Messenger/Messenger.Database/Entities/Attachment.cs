using System;

namespace Messenger.Data.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public required Message Message { get; set; }
        public required string StorageLocation { get; set; }
        public DateTime ChangeTS { get; set; }
    }
}