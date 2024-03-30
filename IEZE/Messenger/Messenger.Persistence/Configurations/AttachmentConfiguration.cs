using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("Attachments");

            builder.HasKey(a => a.AttachmentID);

            builder.Property(a => a.MessageID)
                   .IsRequired();

            builder.Property(a => a.AttachmentName)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(a => a.AttachmentURL)
                   .IsRequired();

            builder.Property(a => a.UploadedByUserID)
                   .IsRequired();

            builder.Property(a => a.UploadedAt)
                   .IsRequired();

            builder.HasOne(a => a.Message)
                   .WithMany(m => m.Attachments)
                   .HasForeignKey(a => a.MessageID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.UploadedByUser)
                   .WithMany()
                   .HasForeignKey(a => a.UploadedByUserID)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
