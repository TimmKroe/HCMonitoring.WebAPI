using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects
{
    public class ServerTypeDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("cores")]
        public int Cores { get; set; }
        [JsonPropertyName("memory")]
        public double Memory { get; set; }
        [JsonPropertyName("disk")]
        public int Disk { get; set; }

    }
}
