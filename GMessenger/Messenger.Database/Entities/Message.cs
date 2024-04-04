using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Database.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int MessageSenderId { get; set; }
        public int MessageReceiverId { get; set; }
        public string MessageText { get; set; }
        public int TredId { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public Attachment Attachment { get; set; }
        public ICollection<User> SenderUsers { get; set; }
        public ICollection<User> ReceiverUsers { get; set; }
        public ICollection<Thred> Threds { get; set; }
    }
}
