// FriendshipConfiguration.cs (Configuration)
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.ToTable("Friends");

            builder.HasKey(f => f.FriendshipID);

            builder.Property(f => f.FriendsUserID1)
                   .IsRequired();

            builder.Property(f => f.FriendsUserID2)
                   .IsRequired();

            builder.Property(f => f.FriendshipStartDate)
                   .IsRequired();

            builder.Property(f => f.FriendshipStatus)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(f => f.User1)
                   .WithMany()
                   .HasForeignKey(f => f.FriendsUserID1)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.User2)
                   .WithMany()
                   .HasForeignKey(f => f.FriendsUserID2)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
