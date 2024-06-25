using Messenger.Core.Services;
using Messenger.Database;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Messenger.Core.Infrastructure
{
    public static class RegisterCore
    {
        public static void RegisterCoreProject(this IServiceCollection services)
        {
            services.RegisterSqliteDb();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IVerificationService, VerificationService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IMessageService, MessageService>();
        }
    }
}