using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Domain
{
    public class Contacts
    {
        [Key]
        public long ContactsId { get; set; }
        [ForeignKey("UserAccount")]
        public long UserAccountId { get; set; }

        [ForeignKey("ContactUserAccount")]
        public long ContactUserAccountId { get; set; }
        public bool IsFriends { get; set; }

        public virtual required UserAccount UserAccount { get; set; }
        public virtual required UserAccount ContactUserAccount { get; set; }
    }
}
