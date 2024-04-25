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
                .HasMaxLength(1200); // Kap max nvarchar apibrezti? ar geriau 1200 palikt, nes max yra 4k

            builder.HasOne(message => message.ChatThread)
                   .WithMany(thread => thread.Message)
                   .HasForeignKey(message => message.ThreadID);

            builder.HasOne(message => message.User)
                   .WithMany(user => user.Message)
                   .HasForeignKey(message => message.SenderUserID)
                   .OnDelete(DeleteBehavior.Restrict); // meta errora kad "may cause cycles or multiple cascade paths" paziuresiu veliau
        }
    }
}
