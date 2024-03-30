namespace Messenger.Persistence.Entities
{
    public class User
    {
        public required int UserID { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public required UserStatus UserStatus { get; set; }
        public required UserProfile UserProfile { get; set; }
        public required UserSettings UserSettings { get; set; }
    }
}
