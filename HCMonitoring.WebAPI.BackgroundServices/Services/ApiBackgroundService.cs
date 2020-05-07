using System.Threading.Tasks;
using HCMonitoring.WebAPI.Adapters.HetznerCloud.Repositories;
using HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.CommandHandler;
using HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.Commands;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Services
{
    public class ApiBackgroundService : IApiBackgroundService
    {
        public void RunApiBackgroundService()
        {
            throw new System.NotImplementedException();
        }

        public async Task RunApiBackgroundServiceAsync()
        {
            GetAllServersCommand command = new GetAllServersCommand();

            HetznerCloudApiRepository hetznerCloudApiRepository = new HetznerCloudApiRepository("SzNnpA76l2hqJgMFyZCPyXDFKt5gZpek4t3N9RiiRGnrVmQuMjAkVXBTcHhbYsFT");

            GetAllServersCommandHandler commandHandler = new GetAllServersCommandHandler(hetznerCloudApiRepository);
            var servers = await commandHandler.Handle(command);
        }
    }
}
