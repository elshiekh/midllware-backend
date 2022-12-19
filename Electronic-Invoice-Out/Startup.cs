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
using System.Text.Json.Serialization;
using static Electronic_Invoice_Out.Extenstion.QueryExtenstion;

namespace Electronic_Invoice_Out
{
    public class Startup
    {
        //MW
        WebAPIProject properties = new WebAPIProject() { Id = 214, Code = 214, Name = "EInvoiceOut", UserName = "EInvoiceOut" };

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
            services.AddControllers().AddJsonOptions(options =>
             options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Invoice Out WebAPI", Version = "v1" });
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
                c.DescribeAllEnumsAsStrings();
            });

            Action<DBOption> mduOptions = (opt =>
            { // ELEVATUS-DEV -------- ELEVATUS-PROD
                opt.BaseAddress = Configuration["ELECTRONIC-INVOICE-DEV:BaseAddress"];
                opt.JsonFormat = Configuration["ELECTRONIC-INVOICE-DEV:JsonFormat"];
                // HMG PCSID-UserName
                opt.HMGUserName = Configuration["ELECTRONIC-INVOICE-DEV:HMG:UserName"];
                opt.HMGPassword = Configuration["ELECTRONIC-INVOICE-DEV:HMG:Password"];
                opt.PCSID_HMGUserName = Configuration["ELECTRONIC-INVOICE-DEV:HMG:PCSID-UserName"];
                opt.PCSID_HMGPassword = Configuration["ELECTRONIC-INVOICE-DEV:HMG:PCSID-Password"];
                // CS
                opt.CSUserName = Configuration["ELECTRONIC-INVOICE-DEV:CS:UserName"];
                opt.CSPassword = Configuration["ELECTRONIC-INVOICE-DEV:CS:Password"];
                opt.PCSID_CSUserName = Configuration["ELECTRONIC-INVOICE-DEV:CS:PCSID-UserName"];
                opt.PCSID_CSPassword = Configuration["ELECTRONIC-INVOICE-DEV:CS:PCSID-Password"];
                // FM
                opt.FMUserName = Configuration["ELECTRONIC-INVOICE-DEV:FM:UserName"];
                opt.FMPassword = Configuration["ELECTRONIC-INVOICE-DEV:FM:Password"];
                opt.PCSID_FMUserName = Configuration["ELECTRONIC-INVOICE-DEV:FM:PCSID-UserName"];
                opt.PCSID_FMPassword = Configuration["ELECTRONIC-INVOICE-DEV:FM:PCSID-Password"];
                // TASW
                opt.TASWUserName = Configuration["ELECTRONIC-INVOICE-DEV:TASW:UserName"];
                opt.TASWPassword = Configuration["ELECTRONIC-INVOICE-DEV:TASW:Password"];
                opt.PCSID_TASWUserName = Configuration["ELECTRONIC-INVOICE-DEV:TASW:PCSID-UserName"];
                opt.PCSID_TASWPassword = Configuration["ELECTRONIC-INVOICE-DEV:TASW:PCSID-Password"];
            });
            services.Configure(mduOptions);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<DBOption>>().Value);
            //services.Configure<FormOptions>(o =>  // currently all set to max, configure it to your needs!
            //{
            //    o.ValueLengthLimit = int.MaxValue;
            //    o.MultipartBodyLengthLimit = long.MaxValue; // <-- !!! long.MaxValue
            //    o.MultipartBoundaryLengthLimit = int.MaxValue;
            //    o.MultipartHeadersCountLimit = int.MaxValue;
            //    o.MultipartHeadersLengthLimit = int.MaxValue;
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) => { context.Request.EnableBuffering(); await next(); });
         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.Use(async (context, next) =>
            //{
            //    context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = null; // unlimited I guess
            //    await next.Invoke();
            //});

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Invoice Out WebAPI");
                c.DefaultModelsExpandDepth(-1);
            });
        }
    }
}
