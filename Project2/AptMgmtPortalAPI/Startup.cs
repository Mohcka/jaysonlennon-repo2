using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AptMgmtPortalAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Util;

namespace AptMgmtPortalAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AptMgmtDbContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("AptMgmtDbContext")));

            services.AddLogging(logger => 
            {
                Host.CreateDefaultBuilder()
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddConsole();
                });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder => {
                                      builder.WithOrigins(
                                          "http://localhost:4200",
                                          "https://localhost:4200",
                                          "https://revp2t3fe.azurewebsites.net",
                                          "http://revp2t3fe.azurewebsites.net"
                                      );
                                  });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            }).AddApiKeySupport(options => { });

            services.AddMvc();

            services.SetupRepositories();

            // NOTE: This must come after database and logging setup is complete.
            services.SetupAuthorization();

            services.SetupSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AptMgmtDbContext context)
        {
            try
            {
                context.Database.Migrate();
            }
            catch {}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            // NOTE: These need to stay in this order.
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            // NOTE: Swagger must come before UseEndpoints and after UseRouting/Authentication/Authorization.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Apartment Management Portal API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
