using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;
using HCMonitoring.WebAPI.Application.HcMonitoring.Ports;

namespace HCMonitoring.WebAPI.Adapters.SQLServer.MonitoringSqlServer.Repositories
{
    public class ServerRepository : IServerRepository
    {
        public Task<List<ServerDto>> GetAllServersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServerDto> GetServerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void InsertServerAsync(List<ServerDto> serversDtos)
        {
            throw new NotImplementedException();
        }

        public void UpdateServerAsync(ServerDto serverDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteServerAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
