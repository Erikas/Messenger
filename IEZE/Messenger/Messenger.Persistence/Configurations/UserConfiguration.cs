using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserID);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(u => u.PasswordSalt)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(u => u.CreatedAt)
                .IsRequired();

            builder.Property(u => u.ModifiedAt)
                .IsRequired(false);

            builder.HasOne(u => u.UserStatus)
                .WithOne(us => us.User)
                .HasForeignKey<UserStatus>(us => us.UserID);

            builder.HasOne(us => us.UserProfile)
                .WithOne(u => u.User)
                .HasForeignKey<UserProfile>(us => us.UserID);

            builder.HasOne(us => us.UserSettings)
                .WithOne(u => u.User)
                .HasForeignKey<UserSettings>(us => us.UserID);
        }
    }
}
