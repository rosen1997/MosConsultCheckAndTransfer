using System.Threading;
using System.Threading.Tasks;
using CheckAndTransferService.DBCheckAndTransfer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CheckAndTransferService
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public Worker(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {      
            while (!stoppingToken.IsCancellationRequested)
            {
                IServiceScope serviceScope = serviceScopeFactory.CreateScope();
                ICheckAndTransfer checkAndTransfer = serviceScope.ServiceProvider.GetService<ICheckAndTransfer>();
                
                checkAndTransfer.Check(10);
                await Task.Delay(1000, stoppingToken);

                serviceScope.Dispose();
            }
        }
    }
}
