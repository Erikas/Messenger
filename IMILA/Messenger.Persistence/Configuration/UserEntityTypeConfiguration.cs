using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(40);
            builder.Property(u => u.LastName).HasMaxLength(40);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);
            builder.Property(u => u.Country).HasMaxLength(60);

            builder.HasOne(u => u.UserAccount)
                   .WithOne(ua => ua.User)
                   .HasForeignKey<UserAccount>(ua => ua.UserId);
        }
    }
}
