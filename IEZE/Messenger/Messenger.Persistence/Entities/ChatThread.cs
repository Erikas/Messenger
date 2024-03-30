namespace Messenger.Persistence.Entities
{
    public class ChatThread
    {
        public int ThreadID { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsGroup { get; set; }
        public required string GroupName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public required User CreatedByUser { get; set; }
        public required ICollection<ThreadParticipant> Participants { get; set; }
        public required ICollection<Message> Messages { get; set; }
    }
}
