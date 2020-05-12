using System;
using System.Collections.Generic;
using System.Text;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Mappers
{
    public static class ServerTypeDtoExtensions
    {
        public static ServerType ToServerType(this ServerTypeDto serverTypeDto)
        {
            var s = new ServerType();

            s.Id = serverTypeDto.Id;
            s.HetznerId = serverTypeDto.HetznerId;
            s.Name = serverTypeDto.Name;
            s.Description = serverTypeDto.Description;
            s.Cores = serverTypeDto.Cores;
            s.Memory = serverTypeDto.Memory;
            s.Disk = serverTypeDto.Disk;

            return s;
        }

        public static ServerTypeDto ToServerTypeDto(this ServerType serverType)
        {
            var s = new ServerTypeDto();
            s.HetznerId = serverType.HetznerId;
            s.Name = serverType.Name;
            s.Description = serverType.Description;
            s.Cores = serverType.Cores;
            s.Memory = serverType.Memory;
            s.Disk = serverType.Disk;
            
            return s;
        }
    }
}
