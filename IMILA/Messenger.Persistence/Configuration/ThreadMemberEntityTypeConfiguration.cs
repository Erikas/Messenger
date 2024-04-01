using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class ThreadMemberEntityTypeConfiguration : IEntityTypeConfiguration<ThreadMember>
    {
        public void Configure(EntityTypeBuilder<ThreadMember> builder)
        {
          builder.HasKey(tm => tm.Id);
          builder.Property(tm => tm.MemberRole).IsRequired();

        }
    }
}
