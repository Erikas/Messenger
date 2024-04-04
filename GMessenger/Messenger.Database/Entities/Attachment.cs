using System;
using System.Collections.Generic;

namespace Messenger.Database.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int MessageId { get; set; }
        public DateTime UploadTimeStamp { get; set; }
        public ICollection<Message> Messages { get; set; }
        
    }
}
