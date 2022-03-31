using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NCrontab;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CheckBookedWorker
{
    public class BookedWorker : BackgroundService
    {
        private readonly ILogger<BookedWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly CrontabSchedule _schedule;
        private DateTime _nextRun;

        private string Schedule => "0 */2 * * * *";
        public BookedWorker(ILogger<BookedWorker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                var nextRun = _schedule.GetNextOccurrence(now);
                if (nextRun > _nextRun)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var service = scope.ServiceProvider.GetRequiredService<BookedClient>();
                        await service.CheckBooked();

                    }
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }

            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}
