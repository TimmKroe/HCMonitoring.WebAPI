using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects
{
    public class ServerObjectDto
    {
        [JsonPropertyName("servers")]
        public List<ServerDto> Servers { get; set; }
    }
}
