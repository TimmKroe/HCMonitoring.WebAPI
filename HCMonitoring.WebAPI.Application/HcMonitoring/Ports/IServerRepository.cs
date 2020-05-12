using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;
using HCMonitoring.WebAPI.Domain.Domain.Aggregates;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Ports
{
    public interface IServerRepository
    {
        public Task<List<ServerDto>> GetAllServersAsync();
        public Task<ServerDto> GetServerAsync(Guid id);
        public Task InsertServersAsync(List<ServerDto> servers);
        public Task InsertServerAsync(ServerDto serverDto);
        public Task UpdateServerAsync(ServerDto serverDto);
        public Task DeleteServerAsync(Guid id);

        public Task<ServerDto> CheckForExistingServer(ServerDto dto);
    }
}