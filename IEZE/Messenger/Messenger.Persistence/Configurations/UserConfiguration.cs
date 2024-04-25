using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Username)
                .HasMaxLength(50);

            builder.Property(user => user.PasswordHash)
                .HasMaxLength(128);

            builder.Property(user => user.PasswordSalt)
                .HasMaxLength(128);
        }
    }
}
