namespace Messenger.Persistence.Entities
{
    public class ThreadParticipant
    {
        public required int ThreadParticipantID { get; set; }
        public required int ThreadID { get; set; }
        public required int UserID { get; set; }
        public required string ParticipantType { get; set; }

        public required ChatThread ChatThread { get; set; }
        public required User User { get; set; }
    }
}
