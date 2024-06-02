namespace Messenger.WebAPI.Models
{
    public class UserSettingsDto
    {
        public long Id { get; set; }
        public long UserAccountId { get; set; }
        public bool Theme { get; set; }
    }
}
