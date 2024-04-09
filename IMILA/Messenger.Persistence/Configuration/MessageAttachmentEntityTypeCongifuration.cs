using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class MessageAttachmentEntityTypeCongifuration : IEntityTypeConfiguration<MessageAttachment>
    {
        public void Configure(EntityTypeBuilder<MessageAttachment> builder)
        {
            builder.Property(a => a.AttachmentName).HasMaxLength(50);
        }
    }
}
