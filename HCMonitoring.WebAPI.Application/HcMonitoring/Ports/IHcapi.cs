using System.Collections.Generic;
using System.Threading.Tasks;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Ports
{
    public interface IHcapi
    {
        public Task<List<ServerDto>> GetAllServers();
        public Task<ServerDto> GetServerById(int id);
        public Task<List<ImageDto>> GetAllSnapshots();
        public Task<List<ImageDto>> GetAllBackups();
        
    }
}