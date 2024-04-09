namespace Messenger.Persistence.Entities
{
    public class UserSettings
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public bool Setting1 { get; set; }
        public string Setting2 { get; set; }
        public DateTime? ModifiedAt { get; set; }
        
        public virtual User User { get; set; }
    }
}