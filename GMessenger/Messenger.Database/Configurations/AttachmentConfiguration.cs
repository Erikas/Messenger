using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Configurations
{
    internal class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.Property(a => a.Url).HasMaxLength(500);

            builder
             .HasOne(b => b.Message)
             .WithMany(a => a.Attachments)
             .HasForeignKey(b => b.MessageId);
        }
    }
}