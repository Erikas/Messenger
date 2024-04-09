using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    internal class UserStatusConfiguration : IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> builder)
        {

            builder.Property(status => status.Status)
                   .HasMaxLength(10);

            builder.HasOne(userprofile => userprofile.User)
                .WithOne(user => user.UserStatus)
                .HasForeignKey<UserStatus>(userprofile => userprofile.UserID);
        }
    }
}
