namespace Messenger.Persistence.Entities
{
    public class UserStatus
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }
        public DateTime LastActiveAt { get; set; }
        
        public virtual User User { get; set; }
    }
}
