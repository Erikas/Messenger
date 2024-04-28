using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Thread = Messenger.Persistence.Entities.Thread;

namespace Messenger.Persistence.Context
{
    public class MessengerDbContext : DbContext
    {

        public MessengerDbContext(DbContextOptions<MessengerDbContext> options) : base(options)
        {
        }


        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageAttachment> MessageAttachments { get; set; }
        public DbSet<ThreadMember> ThreadMembers { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        string connectionString = "Data Source=DESKTOP-G4FRUOV;Initial Catalog=Messenger;Integrated Security=True;TrustServerCertificate=True";
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}
    }
}
