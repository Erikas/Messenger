namespace Messenger.Persistence.Entities
{
    public class ChatThread
    {
        public int Id { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsGroup { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public User User { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<ThreadParticipant> ThreadParticipant { get; set; }
    }
}
