using System;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    internal class Server
    {
        public Guid Id { get; set; }
        public int HetznerId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }

        // NETWORK
        public string Ipv4Ip { get; set; }
        public string Ipv4DnsPtr { get; set; }
        public string Ipv6Ip { get; set; }
        public string Ipv6DnsPtrIp { get; set; }
        public string Ipv6DnsPtr { get; set; }

        // Floating IPs

        // Server Type
        public ServerType ServerType { get; set; }

        // DATACENTER
        public int DcId { get; set; }
        public string DcName { get; set; }
        public string DcDescription { get; set; }

        // Image
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageDescription { get; set; }

        // Protection
        public bool IsProtected { get; set; }

        // Backup Window
        public string BackupWindow { get; set; }

        // Traffic
        public int OutgoingTraffic { get; set; }
        public int IngoingTraffic { get; set; }
        public int IncludedTraffic { get; set; }


        // per Server Settings
        public bool IsVisible { get; set; } // if it is visible on the 
        public bool IsMonitored { get; set; }

    }
}
