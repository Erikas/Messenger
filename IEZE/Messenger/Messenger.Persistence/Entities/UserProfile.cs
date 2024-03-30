namespace Messenger.Persistence.Entities
{
    public class UserProfile
    {
        public required int ProfileID { get; set; }
        public required int UserID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required byte[] ProfilePicture { get; set; }
        public required string Bio { get; set; }
        public required DateTime? BirthDate { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime ModifiedAt { get; set; }
        public required User User { get; set; }
    }
}
