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
             .HasOne(b => b.MessangeReceiver)
             .WithMany(a => a.MessangeReceivers)
             .HasForeignKey(b => b.MessageReceiverId)
             .OnDelete(DeleteBehavior.NoAction);

            builder
             .HasOne(b => b.MessangeSender)
             .WithMany(a => a.MessangeSenders)
             .HasForeignKey(b => b.MessageSenderId)
             .OnDelete(DeleteBehavior.NoAction);

            builder
             .HasOne(b => b.Thread)
             .WithMany(a => a.Messages)
             .HasForeignKey(b => b.TredId);
        }
    }
} 