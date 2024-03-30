// UserStatusConfiguration.cs (Configuration)
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    public class UserStatusConfiguration : IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> builder)
        {
            builder.ToTable("UserStatus");

            builder.HasKey(u => u.StatusID);

            builder.Property(u => u.Status)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(u => u.LastActiveAt)
                   .IsRequired();

            builder.HasOne(us => us.User)
                .WithOne(u => u.UserStatus)
                .HasForeignKey<UserStatus>(us => us.UserID);
        }
    }
}
