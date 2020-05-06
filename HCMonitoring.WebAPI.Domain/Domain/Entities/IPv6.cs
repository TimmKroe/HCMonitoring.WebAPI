using System;
using System.Collections.Generic;
using System.Text;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    public class IPv6
    {
        public Guid Id { get; set; }
        public string Ip { get; set; }
        public bool IsBlocked { get; set; }
        public string[] DnsPtr { get; set; }
    }
}
