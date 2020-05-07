using System;
using System.Collections.Generic;
using System.Text;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;
using HCMonitoring.WebAPI.Domain.Domain.Aggregates;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Mappers
{
    public static class ServerDtoExtensions
    {
        public static Server ToServer(this ServerDto serverDto)
        {
            var server = new Server();

            server.HetznerId = serverDto.HetznerId;
            server.Name = serverDto.Name;
            server.Status = serverDto.Status;
            server.Created = serverDto.Created;
            server.IPv4 = serverDto.PublicNet.IPv4.ToIPv4();
            server.IPv6 = serverDto.PublicNet.IPv6.ToIPv6();
            server.ServerType = serverDto.ServerType.ToServerType();
            server.Datacenter = serverDto.Datacenter.ToDatacenter();
            server.Image = serverDto.Image.ToImage();
            server.Protection = serverDto.Protection.ToProtection();
            server.BackupWindow = serverDto.BackupWindow;
            server.OutgoingTraffic = serverDto.OutgoingTraffic;
            server.IngoingTraffic = serverDto.IngoingTraffic;
            server.IncludedTraffic = serverDto.IncludedTraffic;

            return server;
        }
    }
}
