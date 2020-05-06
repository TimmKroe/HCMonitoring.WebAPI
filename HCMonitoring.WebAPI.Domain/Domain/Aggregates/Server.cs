using System;
using HCMonitoring.WebAPI.Domain.Domain.Entities;

namespace HCMonitoring.WebAPI.Domain.Domain.Aggregates
{
    public class Server
    {
        public Guid Id { get; set; }
        public int HetznerId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }

        // NETWORK
        public IPv4 IPv4 { get; set; }
        public IPv6 IPv6 { get; set; }

        // Floating IPs

        // Server Type
        public ServerType ServerType { get; set; }

        // DATACENTER
        public Datacenter Datacenter { get; set; }

        // Image
        public Image Image { get; set; }

        // Protection
        public Protection Protection { get; set; }

        // Backup Window
        public string BackupWindow { get; set; }

        // Traffic
        public long OutgoingTraffic { get; set; }
        public long IngoingTraffic { get; set; }
        public long IncludedTraffic { get; set; }


        // per Server Settings
        public bool IsVisible { get; set; } // if it is visible on the public status page
        public bool IsMonitored { get; set; } // if it is monitored (mail notifications etc)
        public bool IsIpsVisible { get; set; }
    }
}
