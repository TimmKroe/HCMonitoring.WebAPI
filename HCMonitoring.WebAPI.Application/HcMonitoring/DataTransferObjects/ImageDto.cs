using System;
using System.Text.Json.Serialization;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects
{
    public class ImageDto
    {
        [JsonPropertyName("id")]
        public int HetznerId { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("image_size")]
        public string ImageSize { get; set; }
        [JsonPropertyName("disk_size")]
        public double DiskSize { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        [JsonPropertyName("created_from")]
        public string FromServerId { get; set; }
        [JsonPropertyName("bound_to")]
        public string BoundServerId { get; set; } // Backup only
        [JsonPropertyName("os_flavour")]
        public string OsFlavour { get; set; }
        [JsonPropertyName("os_version")]
        public string OsVersion { get; set; }
    }
}
