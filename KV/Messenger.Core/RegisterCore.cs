using Messenger.Core.Services;
using Messenger.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Messenger.Core
{
    public static class RegisterCore
    {
        public static void RegisterCoreServices(this IServiceCollection services)
        {
            services.RegisterSqliteDb();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IVerificationService, VerificationService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
        }
    }
}