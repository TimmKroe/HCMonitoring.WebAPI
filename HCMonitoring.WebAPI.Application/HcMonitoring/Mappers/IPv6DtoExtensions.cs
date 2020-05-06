using System;
using System.Collections.Generic;
using System.Text;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Mappers
{
    public static class IPv6DtoExtensions
    {
        public static IPv6 ToIPv6(this IPv6Dto iPv6Dto)
        {
            var ip = new IPv6();

            ip.Ip = iPv6Dto.Ip;
            ip.IsBlocked = iPv6Dto.IsBlocked;
            ip.DnsPtr = iPv6Dto.DnsPtr;

            return ip;
        }
    }
}
