using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Data.Configurations
{
    internal class ChatEntityTypeConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable(nameof(Chat));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ChangeTS)
                   .HasDefaultValue(DateTime.UtcNow);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(x => x.Participants)
                   .WithOne(x => x.Chat)
                   .HasForeignKey(x => x.ChatId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Messages)
                   .WithOne(x => x.Chat)
                   .HasForeignKey(x => x.ChatId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}