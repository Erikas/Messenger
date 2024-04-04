using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
             .HasOne(b => b.SenderUsers)
             .WithMany()
             .HasForeignKey(b => b.MessageSenderId);

            builder
             .HasOne(b => b.ReceiverUsers)
             .WithMany()
             .HasForeignKey(b => b.MessageReceiverId);

            builder
             .HasOne(b => b.Threds)
             .WithMany()
             .HasForeignKey(b => b.TredId);
        }
    }
}
