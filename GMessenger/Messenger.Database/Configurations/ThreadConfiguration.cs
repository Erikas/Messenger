using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Configurations
{
    internal class ThreadConfiguration : IEntityTypeConfiguration<Entities.Thread>
    {
        public void Configure(EntityTypeBuilder<Entities.Thread> builder)
        {
            builder.Property(t => t.ChatName).HasMaxLength(50);
        }
    }
}