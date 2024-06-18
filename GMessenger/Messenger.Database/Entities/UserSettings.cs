namespace Messenger.Database.Entities
{
    public class UserSettings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Theme { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastTimeActive { get; set; }
        public required virtual User User { get; set; }
    }
}