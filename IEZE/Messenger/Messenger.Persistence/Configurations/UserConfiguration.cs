using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(username => username.Username)
                .HasMaxLength(50);

            builder.Property(passwordhash => passwordhash.PasswordHash)
                .HasMaxLength(128);

            builder.Property(passwordSalt => passwordSalt.PasswordSalt)
                .HasMaxLength(128);

        }
    }
}
