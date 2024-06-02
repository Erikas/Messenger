using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class MessageAttachmentEntityTypeCongifuration : IEntityTypeConfiguration<MessageAttachment>
    {
        public void Configure(EntityTypeBuilder<MessageAttachment> builder)
        {
            builder.ToTable(nameof(MessageAttachment));

            builder.Property(a => a.Name).HasMaxLength(50);

            builder.HasOne(u => u.Message)
                   .WithMany(u => u.MessageAttachments)
                   .HasForeignKey(u => u.MessageId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
