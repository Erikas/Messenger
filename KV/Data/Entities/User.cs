namespace Messenger.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime ChangeTS { get; set; }
        public ContactBook? ContactBook { get; set; }
        public ICollection<Participant>? Participants { get; set; }
        public ICollection<Contact>? Contacts { get; set; }
    }
}