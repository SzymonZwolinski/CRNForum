using Microsoft.Extensions.Hosting;
using Platender.Core.Services;

namespace Platender.Infrastructure.ScheduledTasks
{
    public class CreateTopLikesViewsTask : IHostedService, IDisposable
    {
        private readonly ILikesService _likesService;
        private Timer _timer;

        public CreateTopLikesViewsTask(ILikesService likesService)
        {
            _likesService = likesService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Scheduled Task should start everyday on 3 AM
            var scheduledTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 50, 0);

            var timeToFirstRun = scheduledTime - DateTime.Now;
            if (timeToFirstRun < TimeSpan.Zero)
            {
                timeToFirstRun = timeToFirstRun.Add(new TimeSpan(24, 0, 0));
            }

            _timer = new Timer(
                DoWork,
                null,
                timeToFirstRun,
                TimeSpan.FromHours(24));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _likesService.CreateOrReplaceSpottsAndPlatesViewAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

    }
}
