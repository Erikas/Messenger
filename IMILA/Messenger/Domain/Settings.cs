using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Domain
{
    public class Settings
    {
        [Key]
        public long SettingsId { get; set; }

        [ForeignKey("UserAccount")]
        public long UserAccountId { get; set; }
        public required bool Theme {  get; set; }
        public virtual required UserAccount UserAccount { get; set; }
    }
}
