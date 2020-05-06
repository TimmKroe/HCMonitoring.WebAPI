using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HCMonitoring.WebAPI.Domain.Domain.Entities
{
    public class Datacenter
    {
        public Guid Id { get; set; }
        public int HetznerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
