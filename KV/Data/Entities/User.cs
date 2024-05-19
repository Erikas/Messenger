namespace Messenger.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime ChangeTS { get; set; }
    }
}