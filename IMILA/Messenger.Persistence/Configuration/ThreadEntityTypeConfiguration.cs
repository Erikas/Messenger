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

            builder.HasOne(u => u.UserAccount)
                   .WithMany(u => u.Threads)
                   .HasForeignKey(u => u.CreationUserAccountId);
        }
    }
}
