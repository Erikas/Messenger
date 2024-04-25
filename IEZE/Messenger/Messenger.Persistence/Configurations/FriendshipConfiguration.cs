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

            // cia ne iki galo veikia su migracija paziuresiu veliau ant FriendsUserID2 uzdeda fk, ant FriendsUserID1 ne
            builder.HasOne(friendship => friendship.User)
                   .WithMany(user => user.Friendship)
                   .HasForeignKey(friendship => friendship.FriendsUserID1);

            builder.HasOne(friendship => friendship.User)
                   .WithMany(user => user.Friendship)
                   .HasForeignKey(friendship => friendship.FriendsUserID2);
        }
    }
}
