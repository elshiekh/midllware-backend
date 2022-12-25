using APIMiddleware.Core;
using APIMiddleware.Core.DTO;
using external_portal_in.Helper;
using external_portal_in.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace external_portal_in
{
    public class Startup
    {
        //MW
        // WebAPIProject properties = new WebAPIProject() { Id = 8, Code = 8, Name = "HMGOnBaseOut", UserName = "HmgOnBase" };
        WebAPIProject properties = new WebAPIProject() { Id = 210, Code = 210, Name = " externalPortalIn", UserName = "externalPortalIn" };
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers().AddXmlSerializerFormatters();
            //services.AddResponseCaching();
            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "External Portal-In API", Version = "v1" });
            });

            //------ Add Memory Cache
            //services.AddMemoryCache();

            Action<DBOption> mduOptions = (opt =>
            {
                opt.DbConection = Configuration["ConnectionStrings:ERPConn"];
            });
            services.Configure(mduOptions);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<DBOption>>().Value);

            //MW
            services.RegsiterAPIMiddlewareConfiguration(Configuration);

            //services.AddResponseCompression();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) => { context.Request.EnableBuffering(); await next(); });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //MW
            app.UseMiddleware<ApiLogging>(properties);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseResponseCaching();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // app.UseResponseCompression();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "External Portal-In API");
                c.DefaultModelsExpandDepth(-1);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
