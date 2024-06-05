namespace Messenger.Persistence.Entities.Common
{
    internal interface IAuditable
    {
        public DateTime CreationTS { get; set; }
        public DateTime ModificationTS { get; set; }
    }
}
