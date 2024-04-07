using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        internal void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder
            .HasOne(b => b.Messages)
            .WithMany()
            .HasForeignKey(b => b.MessageId); ///i messenger configuration
        }
    }
}
