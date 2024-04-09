using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class MessageEntityTypeConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(m => m.MessageContent).HasMaxLength(2000);

            builder.HasMany(m => m.MessageAttachments)
                   .WithOne(a => a.Message)
                   .HasForeignKey(m => m.MessageId);

        }
    }
}
