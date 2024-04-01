using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class MessageEntityTypeConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.MessageContent).IsRequired();

            builder.HasMany(m => m.MessageAttachments)
                   .WithOne(a => a.Message)
                   .HasForeignKey(m => m.MessageId);

              
        }
    }
}
