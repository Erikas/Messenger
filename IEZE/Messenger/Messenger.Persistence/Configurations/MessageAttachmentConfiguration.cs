using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    internal class MessageAttachmentConfiguration : IEntityTypeConfiguration<MessageAttachment>
    {
        public void Configure(EntityTypeBuilder<MessageAttachment> builder)
        {
            builder.Property(attachment => attachment.AttachmentName)
                   .HasMaxLength(255);

            builder.Property(attachment => attachment.AttachmentURL)
                   .HasMaxLength(1200); 

            builder.HasOne(attachment => attachment.Message)
                   .WithMany(message => message.MessageAttachment)
                   .HasForeignKey(attachment => attachment.MessageID);

            builder.HasOne(attachment => attachment.User)
                   .WithMany(users => users.MessageAttachment)
                   .HasForeignKey(attachment => attachment.UploadedByUserID)
                   .OnDelete(DeleteBehavior.Restrict); // meta errora kad "may cause cycles or multiple cascade paths" paziuresiu veliau
        }
    }
}
