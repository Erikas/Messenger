namespace Messenger.Database.Entities
{
    public class ThreadParticipants
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ThreadId { get; set; }
        public required virtual Thread Thread { get; set; }
        public required virtual User User { get; set; }
    }
}