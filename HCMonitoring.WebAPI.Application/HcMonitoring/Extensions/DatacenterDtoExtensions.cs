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

        public static DatacenterDto ToDatacenterDto(this Datacenter datacenter)
        {
            var d = new DatacenterDto();
            d.Id = datacenter.Id;
            d.HetznerId = datacenter.HetznerId;
            d.Name = datacenter.Name;
            d.Description = datacenter.Description;

            return d;
        }
    }
}
