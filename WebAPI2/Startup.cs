using APIMiddleware.Core;
using APIMiddleware.Core.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebAPI2
{
    public class Startup
    {
        WebAPIProject properties = new WebAPIProject() { Id = 202, Name = "WEBAPI2" };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddXmlSerializerFormatters();
            services.AddSwaggerGen(c =>{c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI 2 V1", Version = "v1" });});
            services.Configure<CookiePolicyOptions>(options =>{
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.RegsiterAPIMiddlewareConfiguration(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.Use(async (context, next) => { context.Request.EnableBuffering(); await next(); });

            app.UseMiddleware<ApiLoggingMiddleware>(properties);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI 2 V1"); });
        }
    }
}
