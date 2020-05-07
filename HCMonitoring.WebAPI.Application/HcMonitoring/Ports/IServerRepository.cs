using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Ports
{
    public interface IServerRepository
    {
        public Task<List<ServerDto>> GetAllServersAsync();
        public Task<ServerDto> GetServerAsync(Guid id);
        public void InsertServerAsync(List<ServerDto> serversDtos);
        public void UpdateServerAsync(ServerDto serverDto);
        public void DeleteServerAsync(Guid id);
    }
}
