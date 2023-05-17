using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.BackgroundMS_Services
{
    public class AutoSendEmailEmployeesummaryReport : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        public AutoSendEmailEmployeesummaryReport(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stopingToken)
        {
            while (!stopingToken.IsCancellationRequested)
            {
                var currentTime = DateTime.Now;
                if (currentTime.Hour == 9 && currentTime.Minute == 0)
                {
                    using (var service = serviceProvider.CreateScope())
                    {
                        //var EmailAlertService = service.ServiceProvider.GetRequiredService<IEmailAlert>();
                        //try
                        //{
                        //    await EmailAlertService.SendSummaryReportAsync();
                        //    //logger.LogInformation("Email Summary Report sent successfully at {0}", currentTime);
                        //}
                        //catch (Exception)
                        //{
                        //    //logger.LogError(ex, "Error sending email Summary Report at {0}", currentTime);
                        //}
                    }
                }
                //logger.LogInformation("Summary Report Service is Working");
                await Task.Delay(TimeSpan.FromSeconds(30), stopingToken);
            }
        }
    }
}
