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

        public static IPv4Dto ToIPv4Dto(this IPv4 ipv4)
        {
            var ip = new IPv4Dto();
            
            ip.Ip = ipv4.Ip;
            ip.IsBlocked = ipv4.IsBlocked;
            ip.DnsPtr = ipv4.DnsPtr;

            return ip;
        }
    }
}
