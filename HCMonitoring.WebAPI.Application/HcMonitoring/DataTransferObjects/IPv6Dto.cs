using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    public class IPv6Dto
    {
        [JsonPropertyName("ip")]
        public string Ip { get; set; }
        [JsonPropertyName("blocked")]
        public bool IsBlocked { get; set; }
        [JsonPropertyName("dns_ptr")]
        public string[] DnsPtr { get; set; }
    }
}
