namespace Messenger.Persistence.Entities
{
    public class ThreadParticipant
    {
        public int Id { get; set; }
        public int ThreadID { get; set; }
        public int UserID { get; set; }
        public string ParticipantType { get; set; }

        public virtual ChatThread ChatThread { get; set; }
        public virtual User User { get; set; }
    }
}
