using CheckAndTransferService.DBCheckAndTransfer;
using CheckAndTransferService.Repository;
using CheckAndTransferService.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CheckAndTransferService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<MosConsultTestDbContext>(options => { options.UseSqlServer("Data Source=DESKTOP-JCRR398\\PROJECTSSERVER;Initial Catalog=MosConsultTestDb;Integrated Security=True;"); });
                    services.AddTransient<IUnitOfWork, UnitOfWork>();
                    services.AddTransient<ICheckAndTransfer, CheckAndTransfer>();
                    services.AddHostedService<Worker>();
                }).UseWindowsService();
    }
}
