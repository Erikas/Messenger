using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    internal class ChatThreadConfiguration : IEntityTypeConfiguration<ChatThread>
    {
        public void Configure(EntityTypeBuilder<ChatThread> builder)
        {

            builder.Property(gname => gname.GroupName)
                   .HasMaxLength(100);

            builder.HasOne(thread => thread.User)
                   .WithMany(user => user.ChatThread)
                   .HasForeignKey(thread => thread.CreatedByUserID);
        }
    }
}
