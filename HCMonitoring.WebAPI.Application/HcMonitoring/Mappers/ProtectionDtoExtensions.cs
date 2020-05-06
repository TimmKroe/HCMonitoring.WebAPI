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
    }
}
