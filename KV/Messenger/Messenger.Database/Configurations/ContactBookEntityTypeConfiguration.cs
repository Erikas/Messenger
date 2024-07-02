using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Messenger.Data.Configurations
{
    internal class ContactBookEntityTypeConfiguration : IEntityTypeConfiguration<ContactBook>
    {
        public void Configure(EntityTypeBuilder<ContactBook> builder)
        {
            builder.ToTable(nameof(ContactBook));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ChangeTS)
                   .HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(x => x.OwnerUser)
                   .WithOne(x => x.ContactBook)
                   .HasForeignKey<ContactBook>(x => x.OwnerUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Contacts)
                   .WithOne(x => x.ContactBook)
                   .HasForeignKey(x => x.ContactBookId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}