namespace Messenger.Domain.Common
{
    public class BaseDomain
    {
        public required DateTime CreationTS { get; set; }
        public DateTime? ModificationTS { get; set; }
    }
}
