using System.Collections.Generic;
using System.Threading.Tasks;
using HCMonitoring.WebAPI.Adapters.HetznerCloud.Repositories;
using HCMonitoring.WebAPI.Adapters.SQLServer.MonitoringSqlServer.Repositories;
using HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.CommandHandler;
using HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.Commands;
using HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.Queries;
using HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.QueryHandler;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;
using HCMonitoring.WebAPI.Application.HcMonitoring.Mappers;
using Microsoft.Extensions.Configuration;

namespace HCMonitoring.WebAPI.BackgroundServices.Services
{
    public class ApiBackgroundService : IApiBackgroundService
    {
        public IConfiguration Configuration { get; }
        public ApiBackgroundService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task RunApiBackgroundServiceAsync()
        {
            GetAllServersCommand command = new GetAllServersCommand();

            HetznerCloudApiRepository hetznerCloudApiRepository = new HetznerCloudApiRepository(Configuration["ApiKeys:DevTest"]);

            GetAllServersCommandHandler commandHandler = new GetAllServersCommandHandler(hetznerCloudApiRepository);
            var servers = await commandHandler.Handle(command);

            var workingServers = new List<ServerDto>();
            servers.ForEach(server =>
            {
                workingServers.Add(server.ToServerDto());
            });
            
            
            InsertAllServersQuery query = new InsertAllServersQuery(workingServers);
            ServerRepository serverRepository = new ServerRepository(Configuration);
            InsertAllServersQueryHandler queryHandler = new InsertAllServersQueryHandler(serverRepository);
            await queryHandler.Handle(query);
        }
    }
}
