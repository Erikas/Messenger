using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(message => message.Content)
                .HasMaxLength(1200);

            builder.HasOne(message => message.ChatThread)
                .WithMany(thread => thread.Message)
                .HasForeignKey(message => message.ThreadID);

            builder.HasOne(message => message.User)
                .WithMany(user => user.Message)
                .HasForeignKey(message => message.SenderUserID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
