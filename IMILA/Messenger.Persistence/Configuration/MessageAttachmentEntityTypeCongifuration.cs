using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class MessageAttachmentEntityTypeCongifuration : IEntityTypeConfiguration<MessageAttachment>
    {
        public void Configure(EntityTypeBuilder<MessageAttachment> builder)
        {
            builder.HasKey(a  => a.Id);
            builder.Property(a => a.AttachmentName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.AttachmentBlobUrl).IsRequired();
        }
    }
}
