using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Data.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public string? Name { get; set;}
        public DateTime ChangeTS { get; set; }
        public ICollection<Message>? Messages { get; set; }
        public ICollection<Participant>? Participants { get; set; }
    }
}