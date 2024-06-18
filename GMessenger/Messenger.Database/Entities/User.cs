namespace Messenger.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PictureUrl { get; set; }
        public DateTime AccountCreationDaten { get; set; }
        public required virtual UserSettings UserSettings { get; set; }
        public required virtual ICollection<Friend> Friends { get; set; }
        public required virtual ICollection<Friend> UserFriends { get; set; }
        public required virtual ICollection<ThreadParticipants> ThreadParticipants { get; set;}
        public required virtual ICollection<Message> MessangeSenders { get; set; }
        public required virtual ICollection<Message> MessangeReceivers { get; set; }
    }
}