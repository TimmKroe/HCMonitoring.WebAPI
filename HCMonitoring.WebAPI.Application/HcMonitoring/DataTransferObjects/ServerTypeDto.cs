using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects
{
    public class ServerTypeDto
    {
        public Guid Id { get; set; }
        [JsonPropertyName("id")]
        public int HetznerId { get; set; }
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
