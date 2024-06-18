using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Messenger.Database.Context
{
    public class MessengerDBContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ThreadParticipants> ThreadParticipants { get; set; }
        public DbSet<Entities.Thread> Threads { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);Database=GMessenger;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }
}