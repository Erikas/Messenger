using System.ComponentModel.DataAnnotations;

namespace Messenger.Domain
{
    public class Contacts
    {
        [Key]
        public long ContactsId { get; set; }
        public required List<UserAccount> UserAccountId { get; set; }
        public required List<UserAccount> ContactUserAccountId { get; set; }
        public bool IsFriends { get; set; }

    }
}
