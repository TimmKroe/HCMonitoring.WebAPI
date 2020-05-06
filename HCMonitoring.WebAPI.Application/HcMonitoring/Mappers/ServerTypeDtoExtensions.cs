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

            s.HetznerId = serverTypeDto.Id;
            s.Name = serverTypeDto.Name;
            s.Description = serverTypeDto.Description;
            s.Cores = serverTypeDto.Cores;
            s.Memory = serverTypeDto.Memory;
            s.Disk = serverTypeDto.Disk;

            return s;
        }
    }
}
