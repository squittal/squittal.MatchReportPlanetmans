using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using squittal.MatchReportPlanetmans.Data;
using squittal.MatchReportPlanetmans.Services;
using squittal.MatchReportPlanetmans.Services.Planetside;
using squittal.MatchReportPlanetmans.Services.ScrimMatchReports;
using System;

namespace squittal.MatchReportPlanetmans
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSignalR();

            services.AddDbContext<PlanetmansDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PlanetmansDbContext"),
                                        sqlServerOptionsAction: sqlOptions =>
                                        {
                                            sqlOptions.EnableRetryOnFailure(
                                                maxRetryCount: 5,
                                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                                errorNumbersToAdd: null);
                                        }));

            services.AddSingleton<IDbContextHelper, DbContextHelper>();

            services.AddSingleton<IZoneService, ZoneService>();

            services.AddSingleton<IFacilityService, FacilityService>();

            services.AddSingleton<IWorldService, WorldService>();

            services.AddSingleton<IScrimMatchReportDataService, ScrimMatchReportDataService>();

            services.AddSingleton<IDbSeeder, DbSeeder>();

            services.AddSingleton<IApplicationDataLoader, ApplicationDataLoader>();
            services.AddHostedService<ApplicationDataLoaderHostedService>();

            services.AddSingleton<ISqlScriptRunner, SqlScriptRunner>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
