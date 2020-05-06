using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    public class ProtectionDto
    {
        [JsonPropertyName("delete")]
        public bool Delete { get; set; }
        [JsonPropertyName("rebuild")]
        public bool Rebuild { get; set; }
    }
}
