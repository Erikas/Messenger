namespace Messenger.Persistence.Entities
{
    public class UserSettings
    {
        public int SettingID { get; set; }
        public int UserID { get; set; }
        public bool? Setting1 { get; set; }
        public required string Setting2 { get; set; }
        public DateTime ModifiedAt { get; set; }
        public required User User { get; set; }
    }
}