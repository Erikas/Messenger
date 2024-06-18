namespace Messenger.Database.Entities
{
    public class Thread
    {
        public int Id { get; set; }
        public required string ChatName { get; set;}
        public bool IsGroupChat { get; set;}
        public required virtual ICollection<Message> Messages { get; set; }
        public required virtual ICollection<ThreadParticipants> ThreadParticipants { get; set; }
    }
}