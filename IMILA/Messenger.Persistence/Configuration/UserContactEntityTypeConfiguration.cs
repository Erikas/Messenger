using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class UserContactEntityTypeConfiguration : IEntityTypeConfiguration<UserContact>
    {
        public void Configure(EntityTypeBuilder<UserContact> builder)
        {
            builder.HasOne(u => u.UserAccount)
                   .WithMany(u => u.UserContacts)
                   .HasForeignKey(u => u.UserAccountId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.ContactUserAccount)
                   .WithMany(u => u.ContactUserContacts)
                   .HasForeignKey(u => u.ContactUserAccountId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
