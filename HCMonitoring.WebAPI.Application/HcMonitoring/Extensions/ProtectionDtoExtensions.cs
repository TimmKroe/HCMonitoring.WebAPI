using System;
using System.Collections.Generic;
using System.Text;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Mappers
{
    public static class ProtectionDtoExtensions
    {
        public static Protection ToProtection(this ProtectionDto dto)
        {
            var p = new Protection();

            p.Delete = dto.Delete;
            p.Rebuild = dto.Rebuild;

            return p;
        }

        public static ProtectionDto ToProtectionDto(this Protection protection)
        {
            var p = new ProtectionDto();
            p.Delete = protection.Delete;
            p.Rebuild = protection.Rebuild;

            return p;
        }
    }
}
