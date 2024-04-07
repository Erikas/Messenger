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
            .HasOne(b => b.Users)
            .WithMany()
            .HasForeignKey(b => b.UserId);

            builder
            .HasOne(b => b.UserFriends)
            .WithMany()
            .HasForeignKey(b => b.UserFriendId);
        }
    }
}
