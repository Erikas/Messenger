using Messenger.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using Attachment = Messenger.Domain.Attachment;

namespace Messenger.Context
{
    public class MessengerDbContext : DbContext
    {
        public MessengerDbContext(DbContextOptions<MessengerDbContext> options) : base(options)
        {
        }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<ThreadMembers> ThreadMembers { get; set; }
        public DbSet<Threads> Threads { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UsersAccount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<UserAccount>()
                .HasKey(ua => ua.UserAccountId);

            modelBuilder.Entity<Settings>()
                .HasKey(s => s.SettingsId);

            modelBuilder.Entity<Contacts>()
                .HasKey(c => c.ContactsId);

            modelBuilder.Entity<Threads>()
                .HasKey(t => t.ThreadId);

            modelBuilder.Entity<Message>()
                .HasKey(m => m.MessageId);

            modelBuilder.Entity<Attachment>()
                .HasKey(a => a.AttachmentId);

            modelBuilder.Entity<ThreadMembers>()
                .HasKey(tm => tm.ThreadMemberId);

            // Relationships:
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserAccount)
                .WithOne(ua => ua.User)
                .HasForeignKey<UserAccount>(ua => ua.UserId);

            modelBuilder.Entity<UserAccount>()
                .HasMany(ua => ua.Settings)
                .WithOne(s => s.UserAccount)
                .HasForeignKey(s => s.UserAccountId);

            modelBuilder.Entity<UserAccount>()
                .HasMany(ua => ua.Contacts)
                .WithOne(c => c.UserAccount)
                .HasForeignKey(c => c.UserAccountId);

            modelBuilder.Entity<UserAccount>()
                .HasMany(ua => ua.ThreadMembers)
                .WithOne(tm => tm.UserAccount)
                .HasForeignKey(tm => tm.ThreadMemberUserAccountId);

            modelBuilder.Entity<Threads>()
                .HasMany(t => t.Messages)
                .WithOne(m => m.Thread)
                .HasForeignKey(m => m.ThreadId);

            modelBuilder.Entity<Message>()
                .HasMany(m => m.Attachments)
                .WithOne(a => a.Message)
                .HasForeignKey(a => a.MessageId);

            modelBuilder.Entity<Threads>()
                .HasMany(t => t.ThreadMembers)
                .WithOne(tm => tm.Thread)
                .HasForeignKey(tm => tm.ThreadId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
