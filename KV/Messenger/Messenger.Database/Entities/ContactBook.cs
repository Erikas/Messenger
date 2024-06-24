using System;
using System.Collections.Generic;

namespace Messenger.Database.Entities
{
    public class ContactBook
    {
        public int Id { get; set; }
        public int OwnerUserId { get; set; }
        public required User OwnerUser { get; set; }
        public ICollection<Contact>? Contacts { get; set; }
        public DateTime ChangeTS { get; set; }
    }
}