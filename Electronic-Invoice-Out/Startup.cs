using APIMiddleware.Core;
using APIMiddleware.Core.DTO;
using Electronic_Invoice_Out.Helper;
using Electronic_Invoice_Out.Service;
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

namespace Electronic_Invoice_Out
{
    public class Startup
    {
        //MW
        WebAPIProject properties = new WebAPIProject() { Id = 214, Code = 214, Name = "ElectronicInvoiceOut", UserName = "ElectronicInvoiceOut" };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //MW
             services.RegsiterAPIMiddlewareConfiguration(Configuration);
             services.AddControllers().AddXmlSerializerFormatters();

            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Electronic Invoice Out WebAPI", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            Action<DBOption> mduOptions = (opt =>
            { // ELEVATUS-DEV -------- ELEVATUS-PROD
              opt.BaseAddress= Configuration["ELECTRONIC-INVOICE-DEV:BaseAddress"];
              opt.JsonFormat= Configuration["ELECTRONIC-INVOICE-DEV:JsonFormat"];
              opt.UserName = Configuration["ELECTRONIC-INVOICE-DEV:UserName"];
              opt.Password = Configuration["ELECTRONIC-INVOICE-DEV:Password"];
            });
            services.Configure(mduOptions);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<DBOption>>().Value);
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

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Electronic Invoice Out WebAPI");
                c.DefaultModelsExpandDepth(-1);
            });
        }
    }
}
