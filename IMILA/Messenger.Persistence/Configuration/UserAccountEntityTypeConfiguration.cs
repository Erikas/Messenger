using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class UserAccountEntityTypeConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasOne(u => u.User)
                   .WithOne(u => u.UserAccount)
                   .HasForeignKey<UserAccount>(u => u.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
