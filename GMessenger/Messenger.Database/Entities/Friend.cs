 namespace Messenger.Database.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserFriendId { get; set; }
        public required virtual User User { get; set; }
        public required virtual User UserFriend { get; set; }
    }
}