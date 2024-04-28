using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class MessageEntityTypeConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(m => m.Content).HasMaxLength(2000);

            builder.HasOne(u => u.Thread)
                   .WithMany(u => u.Messages)
                   .HasForeignKey(u => u.MessageThreadId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.UserAccount)
                   .WithMany(u => u.Messages)
                   .HasForeignKey(u => u.SenderUserAccountId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
