using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MoviesWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();


            try
            {

                CreateHostBuilder(args).Build().Run();

                Log.Information("MoviesWorkes Started");
            }
            catch (System.Exception ex)
            {

                Log.Fatal(ex, "MoviesWorker Failed");
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ActivateWorker>();
                    services.AddSingleton<ActivateArciveClient>();
                })
            .UseSerilog();
    }
}
