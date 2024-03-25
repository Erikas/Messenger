namespace Messenger.Domain
{
    public class BaseDomain
    {
        public required DateTime CreationTS { get; set; }
        public DateTime? ModificationTS { get; set; }
    }
}
