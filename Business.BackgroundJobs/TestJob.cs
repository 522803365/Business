using log4net;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControlCenterServices.BackgroundJobs
{
   public class TestJob: BackgroundService
    {
        private readonly ILog _log;
        public TestJob()
        {
            _log = LogManager.GetLogger(typeof(TestJob));
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var msg = $"CurrentTime:{ DateTime.Now}, Hello World!";
                Console.WriteLine(msg);
                _log.Info(msg);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
