using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    public class ThreadConfiguration : IEntityTypeConfiguration<ChatThread>
    {
        public void Configure(EntityTypeBuilder<ChatThread> builder)
        {
            builder.ToTable("Threads");

            builder.HasKey(t => t.ThreadID);

            builder.Property(t => t.CreatedByUserID)
                   .IsRequired();

            builder.Property(t => t.CreatedAt)
                   .IsRequired();

            builder.Property(t => t.IsGroup)
                   .IsRequired();

            builder.Property(t => t.GroupName)
                   .HasMaxLength(100);

            builder.HasOne(t => t.CreatedByUser)
                   .WithMany()
                   .HasForeignKey(t => t.CreatedByUserID)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
