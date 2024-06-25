using System;
using System.Collections.Generic;

namespace Messenger.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime ChangeTS { get; set; }
        public ContactBook? ContactBook { get; set; }
        public ICollection<Participant>? Participants { get; set; }
        public ICollection<Contact>? Contacts { get; set; }
    }
}