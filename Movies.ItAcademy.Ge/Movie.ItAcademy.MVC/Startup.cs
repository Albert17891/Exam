using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movies.ItAcademy.MVC.Infastructure.Extensions;
using Movies.ItAcademy.MVC.Infastructure.Mapping;
using MoviesManagement.Domain.Models.UserIdentiy;
using MoviesManagement.PersistanceDB.Context;
using MoviesManagement.PersistanceDB.IdentityContext;
using Serilog;

namespace Movies.ItAcademy.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();
            services.AddDbContext<MovieContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MovieConnection")));
            services.AddDbContext<UserContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UserConnection")));
            services.AddMapper();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<UserContext>();

            services.AddAntiforgery(opt =>
            {

                opt.FormFieldName = "MyAntiForgeryField";
                opt.HeaderName = "MyAntiForgeryHeader";
                opt.Cookie.Name = "MyAntiForgeryCookie";

            });

            services.AddControllersWithViews();
            services.AddSession();


            services.AddHealthChecks()
                .AddDbContextCheck<MovieContext>();

            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(5);
                opt.AddHealthCheckEndpoint("HealthCheck", "/health");
            }).AddInMemoryStorage();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");

            //    app.UseHsts();
            //}

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Movie/Error");
            }

            // app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                endpoints.MapHealthChecksUI();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movie}/{action=Index}/{id?}");
            });
        }
    }
}
