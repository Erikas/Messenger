using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class ThreadMemberEntityTypeConfiguration : IEntityTypeConfiguration<ThreadMember>
    {
        public void Configure(EntityTypeBuilder<ThreadMember> builder)
        {
            builder.HasOne(u => u.UserAccount)
                   .WithMany(u => u.ThreadMembers)
                   .HasForeignKey(u => u.ThreadMemberUserAccountId);

            builder.HasOne(u => u.Thread)
                   .WithMany(u => u.ThreadMembers)
                   .HasForeignKey(u => u.ThreadId);
        }
    }
}
