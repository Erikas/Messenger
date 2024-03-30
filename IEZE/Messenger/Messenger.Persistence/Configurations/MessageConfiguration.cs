using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(m => m.MessageID);

            builder.Property(m => m.ThreadID)
                   .IsRequired();

            builder.Property(m => m.SenderUserID)
                   .IsRequired();

            builder.Property(m => m.Content)
                   .IsRequired();

            builder.Property(m => m.SentAt)
                   .IsRequired();

            builder.HasOne(m => m.ChatThread)
                   .WithMany()
                   .HasForeignKey(m => m.ThreadID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.SenderUser)
                   .WithMany()
                   .HasForeignKey(m => m.SenderUserID)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
