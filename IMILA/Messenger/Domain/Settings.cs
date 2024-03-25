using System.ComponentModel.DataAnnotations;

namespace Messenger.Domain
{
    public class Settings
    {
        [Key]
        public long SettingsId { get; set; }
        public required UserAccount UserAccountId { get; set; }
        public required bool Theme {  get; set; }
    }
}
