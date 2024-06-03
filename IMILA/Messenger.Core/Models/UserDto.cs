namespace Messenger.Core.Models
{
    public class UserDto
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public Uri? PictureBlobUrl { get; set; }
        public required string Country { get; set; }
        public DateTime CreationTS { get; set; }
        public DateTime ModificationTS { get; set; }
    }

    public class CreateUserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public Uri? PictureBlobUrl { get; set; }
        public required string Country { get; set; }
    }

}
