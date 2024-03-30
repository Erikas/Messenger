using Microsoft.EntityFrameworkCore;
using Messenger.Persistence.Entities;
using Messenger.Persistence.Configurations;

namespace Messenger.Persistence.Models
{
    public partial class MessengerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friends { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ChatThread> Threads { get; set; }
        public DbSet<ThreadParticipant> ThreadParticipants { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public MessengerContext()
        {
        }

        public MessengerContext(DbContextOptions<MessengerContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=(localdb)\\local;Initial Catalog=Messenger;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FriendshipConfiguration());
            modelBuilder.ApplyConfiguration(new UserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserSettingsConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new ThreadConfiguration());
            modelBuilder.ApplyConfiguration(new ThreadParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
