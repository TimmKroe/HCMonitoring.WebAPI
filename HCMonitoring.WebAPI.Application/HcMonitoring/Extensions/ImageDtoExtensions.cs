using System;
using System.Collections.Generic;
using System.Text;
using HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.Mappers
{
    public static class ImageDtoExtensions
    {
        public static Image ToImage(this ImageDto dto)
        {
            var i = new Image();

            i.HetznerId = dto.HetznerId;
            i.Type = dto.Type;
            i.Status = dto.Status;
            i.Name = dto.Name;
            i.Description = dto.Description;

            // check if image size is numeric
            if (double.TryParse(dto.ImageSize, out var tmp))
            {
                i.ImageSize = tmp;
            }
            else
            {
                i.ImageSize = 0.0;
            }

            i.DiskSize = dto.DiskSize;
            i.Created = dto.Created;

            // check if created from is numeric
            if (int.TryParse(dto.FromServerId, out var tmp2))
            {
                i.FromServerId = tmp2;
            }
            else
            {
                i.FromServerId = 0;
            }

            // check if bound server id is numeric
            if (int.TryParse(dto.BoundServerId, out var tmp3))
            {
                i.BoundServerId = tmp3;
            }
            else
            {
                i.BoundServerId = 0;
            }

            i.OsFlavour = dto.OsFlavour;
            i.OsVersion = dto.OsVersion;

            return i;
        }
    }
}
