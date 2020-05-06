using System;
using System.Text.Json.Serialization;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        [JsonPropertyName("id")]
        public int HetznerId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double ImageSize { get; set; }
        public double DiskSize { get; set; }
        public DateTime Created { get; set; }
        public int FromServerId { get; set; }
        public int BoundServerId { get; set; } // Backup only
        public string OsFlavour { get; set; }
        public string OsVersion { get; set; }
    }
}
