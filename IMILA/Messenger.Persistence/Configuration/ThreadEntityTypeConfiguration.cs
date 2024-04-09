using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thread = Messenger.Persistence.Entities.Thread;

namespace Messenger.Persistence.Configuration
{
    internal class ThreadEntityTypeConfiguration : IEntityTypeConfiguration<Thread>
    {
        public void Configure(EntityTypeBuilder<Thread> builder)
        {
            builder.Property(t => t.ThreadName).HasMaxLength(100);

            builder.HasMany(t => t.ThreadMembers)
                   .WithOne(tm => tm.Thread)
                   .HasForeignKey(tm => tm.ThreadId);

            builder.HasMany(t => t.Messages)
                   .WithOne(m => m.Thread)
                   .HasForeignKey(m => m.ThreadId);
        }

    }
}
