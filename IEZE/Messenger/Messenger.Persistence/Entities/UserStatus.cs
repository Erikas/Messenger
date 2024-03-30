namespace Messenger.Persistence.Entities
{
    public class UserStatus
    {
        public int StatusID { get; set; }
        public int UserID { get; set; }
        public required string Status { get; set; }
        public DateTime LastActiveAt { get; set; }
        public required User User { get; set; }
    }
}
