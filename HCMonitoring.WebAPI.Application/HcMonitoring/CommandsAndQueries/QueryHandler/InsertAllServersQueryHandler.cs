using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.Queries;
using HCMonitoring.WebAPI.Application.HcMonitoring.Ports;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.CommandsAndQueries.QueryHandler
{
    public class InsertAllServersQueryHandler
    {
        private readonly IServerRepository _serverRepository;

        public InsertAllServersQueryHandler(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task Handle(InsertAllServersQuery query)
        {
            await this._serverRepository.InsertServersAsync(query.servers);
        }
    }
}
