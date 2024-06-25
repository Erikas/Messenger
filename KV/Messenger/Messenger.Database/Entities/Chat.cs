using System;
using System.Collections.Generic;

namespace Messenger.Database.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Message>? Messages { get; set; }
        public ICollection<Participant>? Participants { get; set; }
        public DateTime ChangeTS { get; set; }
    }
}