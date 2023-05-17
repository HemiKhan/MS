using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.BackgroundMS_Services
{
    public class AutoSendEmployeeandVerifiedBySystem : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        public AutoSendEmployeeandVerifiedBySystem(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stopingToken)
        {

            while (!stopingToken.IsCancellationRequested)
            {
                var currentTime = DateTime.Now;
                if (((currentTime.Hour == 9 && currentTime.Minute == 0) || (currentTime.Hour == 16 && currentTime.Minute == 0)))
                {
                    using (var service = serviceProvider.CreateScope())
                    {
                        //var EmailAlertService = service.ServiceProvider.GetRequiredService<IEmailAlert>();
                        //try
                        //{
                        //    await EmailAlertService.SendEmployeeandVerifiedBySystemAsync();
                        //}
                        //catch (Exception)
                        //{
                        //}
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(30), stopingToken);                
            }
        }
    }
}
