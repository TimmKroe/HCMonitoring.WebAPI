using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects
{
    public class PublicNetDto
    {
        [JsonPropertyName("ipv4")]
        public IPv4Dto IPv4 { get; set; }
        [JsonPropertyName("ipv6")]
        public IPv6Dto IPv6 { get; set; }
    }
}
