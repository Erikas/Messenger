﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Data
{
    public static class RegisterDb
    {
        public static void RegisterSqliteDb(this IServiceCollection services)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            string dbPath = Path.Join(path, "messengerDb.db");

            services.AddDbContext<MessengerContext>(options =>
                options.UseSqlite($"Data Source={dbPath}")
                );

            Console.WriteLine($"db registered at {dbPath}");
        }
    }
}