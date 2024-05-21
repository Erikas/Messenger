using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Data.Configurations
{
    internal class AttachmentEntityTypeConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable(nameof(Attachment));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ChangeTS)
                   .HasDefaultValue(DateTime.UtcNow);
        }
    }
}