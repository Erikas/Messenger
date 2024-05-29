using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Data.Configurations
{
    public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable(nameof(Contact));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ChangeTS)
                   .HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(x => x.ContactUser)
                   .WithMany(x => x.Contacts)
                   .HasForeignKey(x => x.ContactUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.ContactUserId, x.ContactBookId })
                   .IsUnique(true);
        }
    }
}