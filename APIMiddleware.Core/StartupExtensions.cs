﻿using APIMiddleware.Core.Services.Implementation;
using APIMiddleware.Core.Services.Interface;
using APIMiddleware.Notification;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIMiddleware.Core
{
    public static class StartupExtensions
    {
        public static void RegsiterAPIMiddlewareConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<ISystemPreferenceService, SystemPreferenceService>();

            services.RegsiterAPIMiddlewareNotification(configuration);
        }
    }
}
