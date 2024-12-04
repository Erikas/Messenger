using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.IO;

namespace Messenger.Data
{
    public class MessengerContextFactory : IDesignTimeDbContextFactory<MessengerContext>
    {
        public MessengerContext CreateDbContext(string[] args)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            string dbPath = Path.Join(path, "messengerDb.db");

            var optionsBuilder = new DbContextOptionsBuilder<MessengerContext>();
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new MessengerContext(optionsBuilder.Options);
        }
    }
}