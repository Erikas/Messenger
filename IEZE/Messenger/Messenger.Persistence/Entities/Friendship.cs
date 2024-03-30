// Friendship.cs (Entity)
namespace Messenger.Persistence.Entities
{
    public class Friendship
    {
        public int FriendshipID { get; set; }
        public int FriendsUserID1 { get; set; }
        public int FriendsUserID2 { get; set; }
        public DateTime FriendshipStartDate { get; set; }
        public required string FriendshipStatus { get; set; }

        public required User User1 { get; set; }
        public required User User2 { get; set; }
    }
}
