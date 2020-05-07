using System;
using System.Collections.Generic;
using System.Text;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Mappers
{
    public static class DatacenterDtoExtensions
    {
        public static Datacenter ToDatacenter(this DatacenterDto dto)
        {
            var d = new Datacenter();

            d.HetznerId = dto.HetznerId;
            d.Name = dto.Name;
            d.Description = dto.Description;

            return d;
        }
    }
}
