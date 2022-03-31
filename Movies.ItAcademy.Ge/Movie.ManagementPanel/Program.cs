using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoviesManagement.Domain.Models.UserIdentiy;
using MoviesManagement.PersistanceDB.Context;
using MoviesManagement.PersistanceDB.IdentityContext;
using MoviesManagement.PersistanceDB.Seed;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Movies.ManagementPanel
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();



            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    var userContext = service.GetRequiredService<UserContext>();
                    var userManager = service.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
                    var movieContext = service.GetRequiredService<MovieContext>();
                    //Seeding Movie
                    MovieSeed.Migrate(movieContext);
                    await MovieSeed.SeedMovie(movieContext);
                    //Seeding User
                    UserSeed.Migrate(userContext);
                    await UserSeed.SeedRolesAsync(roleManager);
                    await UserSeed.SeedAdminAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
