using Messenger.Persistence.Entities.Common;

namespace Messenger.Persistence.Entities
{
    public class User : IAuditable
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public Uri? PictureBlobUrl { get; set; }
        public required string Country { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public DateTime CreationTS { get; set; }
        public DateTime ModificationTS { get; set; }
    }
}
