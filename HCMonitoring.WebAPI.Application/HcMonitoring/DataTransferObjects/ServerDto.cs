using System;
using System.Text.Json.Serialization;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Application.HcMonitoring.DataTransferObjects
{
    [Serializable]
    public class ServerDto
    {
        public Guid Id { get; set; }
        [JsonPropertyName("id")]
        public int HetznerId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        // NETWORK
        [JsonPropertyName("public_net")]
        public PublicNetDto PublicNet { get; set; }

        // Floating IPs
        // TODO

        // Server Type
        [JsonPropertyName("server_type")]
        public ServerTypeDto ServerType { get; set; }

        // DATACENTER
        [JsonPropertyName("datacenter")]
        public DatacenterDto Datacenter { get; set; }

        // Image
        [JsonPropertyName("image")]
        public ImageDto Image { get; set; }

        // Protection
        [JsonPropertyName("protection")]
        public ProtectionDto Protection { get; set; }

        // Backup Window
        [JsonPropertyName("backup_window")]
        public string BackupWindow { get; set; }

        // Traffic
        [JsonPropertyName("outgoing_traffic")]
        public long OutgoingTraffic { get; set; }
        [JsonPropertyName("ingoing_traffic")]
        public long IngoingTraffic { get; set; }
        [JsonPropertyName("included_traffic")]
        public long IncludedTraffic { get; set; }

        public void Update(ServerDto dto)
        {
            HetznerId = dto.HetznerId;
            Name = dto.Name;
            Status = dto.Status;
            Created = dto.Created;
            PublicNet.IPv4 = dto.PublicNet.IPv4;
            PublicNet.IPv6 = dto.PublicNet.IPv6;
            ServerType = dto.ServerType;
            Datacenter = dto.Datacenter;
            Image = dto.Image;
            Protection = dto.Protection;
            BackupWindow = dto.BackupWindow;
            OutgoingTraffic = dto.OutgoingTraffic;
            IngoingTraffic = dto.IngoingTraffic;
            IncludedTraffic = dto.IncludedTraffic;
        }
        
        public override bool Equals(object? obj)
        {
            var o = (ServerDto) obj;
            return base.Equals(obj);
        }
    }
}
