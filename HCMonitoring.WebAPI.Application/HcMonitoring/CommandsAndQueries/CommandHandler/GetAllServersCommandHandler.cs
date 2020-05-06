using System.Collections.Generic;
using System.Threading.Tasks;
using HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.Commands;
using HCMonitoring.WebAPI.Application.HcMonitoring.Mappers;
using HCMonitoring.WebAPI.Application.HcMonitoring.Ports;
using HCMonitoring.WebAPI.Domain.Domain.Aggregates;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.CommandHandler
{
    public class GetAllServersCommandHandler
    {
        private readonly IHcapi _hcapi;

        public GetAllServersCommandHandler(IHcapi hcapi)
        {
            _hcapi = hcapi;
        }

        public async Task<List<Server>> Handle(GetAllServersCommand command)
        {
            var resultServers = await _hcapi.GetAllServers();

            var servers = new List<Server>();

            foreach (var serverDto in resultServers)
            {
                servers.Add(serverDto.ToServer());
            }
            
            return servers;
        }
    }
}