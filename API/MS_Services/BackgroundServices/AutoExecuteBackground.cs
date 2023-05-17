using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.BackgroundMS_Services
{
    public class AutoExecuteBackground : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private Timer? _timer;
        public AutoExecuteBackground(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stopingToken)
        {
            // Schedule the task to run at 9:00 AM every day
            var nextRunTime = GetNextRunTime();
            _timer = new Timer(DoWork!, null, nextRunTime, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var service = serviceProvider.CreateScope();
            //var EmailAlertService = service.ServiceProvider.GetRequiredService<IEmailAlert>();
            //EmailAlertService.SendSummaryReportAsync();
        }             

        private TimeSpan GetNextRunTime()
        {
            var currentTime = DateTime.Now;
            var nextRunTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 9, 0, 0);

            if (currentTime > nextRunTime)
            {
                nextRunTime = nextRunTime.AddDays(1);
            }
            return nextRunTime - currentTime;
        }
    }
}
