using APIMiddleware.Core;
using APIMiddleware.Core.DTO;
using HMGOnBaseIn.Helper;
using HMGOnBaseIn.Service;
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

namespace HMGOnBaseIn
{
    public class Startup
    {
        //MW
        // WebAPIProject properties = new WebAPIProject() { RequestId = 7, Code = 7, Name = "HMGOnBaseIn", UserName = "HmgOnBase" };
        WebAPIProject properties = new WebAPIProject() { Id = 207, Code = 207, Name = "onBaseOut", UserName = "onbaseout" };
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
            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECM OnBase Out", Version = "v1" });
            });


            Action<DBOption> mduOptions = (opt =>
            {
                opt.DbConection = Configuration["ConnectionStrings:ERPConn"];
                opt.OnBaseAPI = Configuration["ConnectionStrings:OnBaseAPI"];
                opt.OnBaseSite = Configuration["ConnectionStrings:OnBaseSite"];
            });
            services.Configure(mduOptions);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<DBOption>>().Value);


            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.RegsiterAPIMiddlewareConfiguration(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) => { context.Request.EnableBuffering(); await next(); });
            // loggerFactory.AddFile("Logs/HMGOnBaseIn-{Date}.txt"); , ILoggerFactory loggerFactory
            // app.UseRequestResponseLogging();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // app.UseRequestResponseLogging();

            //MW
            app.UseMiddleware<ApiLogging>(properties);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            //Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HMG OnBaseOut API");
            //    //c.RoutePrefix = string.Empty;
            //    c.DefaultModelsExpandDepth(-1);
            //});

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECM OnBase Out API");
                c.DefaultModelsExpandDepth(-1);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
