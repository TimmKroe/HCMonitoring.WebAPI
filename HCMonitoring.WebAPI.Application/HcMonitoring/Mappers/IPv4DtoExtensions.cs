using System;
using System.Collections.Generic;
using System.Text;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Mappers
{
    public static class IPv4DtoExtensions
    {
        public static IPv4 ToIPv4(this IPv4Dto iPv4Dto)
        {
            var ip = new IPv4();

            ip.Ip = iPv4Dto.Ip;
            ip.IsBlocked = iPv4Dto.IsBlocked;
            ip.DnsPtr = iPv4Dto.DnsPtr;

            return ip;
        }
    }
}
