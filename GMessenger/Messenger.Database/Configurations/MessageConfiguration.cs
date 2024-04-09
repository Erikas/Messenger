using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Configurations
{
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
             .HasOne(b => b.User1)
             .WithMany(a => a.Messages)
             .HasForeignKey(b => b.MessageReceiverId)
             .OnDelete(DeleteBehavior.ClientSetNull);

            builder
             .HasOne(b => b.User2)
             .WithMany(a => a.Messages2)
             .HasForeignKey(b => b.MessageSenderId)
             .OnDelete(DeleteBehavior.ClientSetNull);

            builder
             .HasOne(b => b.Thread)
             .WithMany(a => a.Messages)
             .HasForeignKey(b => b.TredId);
        }
    }
} 