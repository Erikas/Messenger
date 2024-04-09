using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Configurations
{
    internal class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder
                .HasOne(f => f.User)
                .WithMany(u => u.Friends)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder
                .HasOne(f => f.User2)
                .WithMany(u => u.Friends2)
                .HasForeignKey(f => f.UserFriendId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}