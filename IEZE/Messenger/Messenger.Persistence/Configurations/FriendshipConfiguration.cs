using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    internal class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.Property(friendship => friendship.FriendshipStatus)
                .HasMaxLength(50);

            builder.HasOne(friendship => friendship.FriendId1)
                .WithMany(user => user.FriendshipUser1)
                .HasForeignKey(friendship => friendship.FriendsUserID1)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(friendship => friendship.FriendId2)
                .WithMany(user => user.FriendshipUser2)
                .HasForeignKey(friendship => friendship.FriendsUserID2)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
