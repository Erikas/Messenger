namespace Messenger.Core.Models
{
    public interface IContactDtoModel
    {
        int Id { get; set; }
        string Name { get; }
    }

    internal class ContactDtoModel : IContactDtoModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}