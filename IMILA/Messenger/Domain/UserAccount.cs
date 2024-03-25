using System.ComponentModel.DataAnnotations;

namespace Messenger.Domain
{
    public class UserAccount : BaseDomain
    {
        [Key]
        public long UserAccountId { get; set; }
        public required User UserId { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }
        public required bool IsActive { get; set; }

    }
}
