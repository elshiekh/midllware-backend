using APIMiddleware.Notification.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIMiddleware.Notification
{
    public static class StartupExtensions
    {
        public static void RegsiterAPIMiddlewareNotification(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
