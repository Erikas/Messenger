using System.ComponentModel.DataAnnotations;

namespace Messenger.Domain
{
    public class User : BaseDomain
    {
        [Key]
        public long UserId { get; set; }
        [MaxLength(40)]
        public required string FirstName { get; set; }
        [MaxLength(40)]
        public required string LastName { get; set; }
        [MaxLength(50)]
        public required string Email { get; set; }
        [MaxLength(50)]
        public required string PhoneNumber { get; set; }
        public string? PictureBlobUrl {  get; set; }
        [MaxLength(50)]
        public required string Country { get; set; }

    }
}

