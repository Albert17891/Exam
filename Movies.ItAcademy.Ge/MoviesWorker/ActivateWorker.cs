using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NCrontab;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesWorker
{
    public class ActivateWorker : BackgroundService
    {
        private readonly ILogger<ActivateWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly CrontabSchedule _schedule;
        private DateTime _nextRun;

        private string Schedule => "0 */2 * * * *";
        public ActivateWorker(ILogger<ActivateWorker> logger, IServiceProvider serviceProvider)
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
                var next = _schedule.GetNextOccurrence(now);
                if (next > _nextRun)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var service = scope.ServiceProvider.GetRequiredService<ActivateArciveClient>();
                        await service.ActivateTickets();
                    }
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }

            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}
